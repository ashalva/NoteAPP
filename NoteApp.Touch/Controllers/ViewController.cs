using System;

using UIKit;
using Autofac;
using NoteApp.Core.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using NoteApp.Core.BusinessObjects;
using NoteApp.Touch.Helpers;
using CoreGraphics;
using NoteApp.Touch.Controllers;

namespace NoteApp.Touch
{
	public partial class ViewController : BaseViewController
	{
		private NoteViewModel _viewModel;
		private UITableView _notesTableView;
		private UIActivityIndicatorView _dialog;
		private UIRefreshControl _refresher;
		private NotesTableSource _noteSource;

		public ViewController () : base ()
		{
			using (var scope = App.Container.BeginLifetimeScope ()) {
				_viewModel = scope.Resolve<NoteViewModel> ();
			}
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_dialog = DialogHelper.ShowProgressDialog (new CGRect (0, 0, View.Frame.Width, View.Frame.Height), View);

			Title = "My Notes";
			View.BackgroundColor = UIColor.White;

			NavigationController.NavigationBar.Translucent = false;

			InitUI ();
		}

		private void InitUI ()
		{
			nfloat startY = GetStatusBarHeight ();

			_notesTableView = new UITableView (new CGRect (0, 0, View.Frame.Width, View.Frame.Height - startY));
			_notesTableView.RowHeight = 70;

			_noteSource = new NotesTableSource (null, View.Frame.Width, 70);
			_noteSource.DeleteNote += DeleteNote;
			_noteSource.NoteSelected += NoteSelected;

			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (UIBarButtonSystemItem.Add, (sender, args) => {
					NavigationController.PushViewController (new AddNoteViewController (_viewModel), false);
				})
				, true);

			this.NavigationItem.SetLeftBarButtonItem (
				new UIBarButtonItem ("Log out", UIBarButtonItemStyle.Plain, (sender, args) => {
					UIApplication.SharedApplication.KeyWindow.RootViewController = new UINavigationController (new LoginViewController ());
					Settings.UserId = string.Empty;
				})
				, true);

			_refresher = new UIRefreshControl ();
			_refresher.ValueChanged += Refresh;

			_notesTableView.AddSubview (_refresher);
			View.AddSubview (_notesTableView);
			DialogHelper.DismissProgressDialog (_dialog);
		}

		void NoteSelected (object sender, Note e)
		{
			NavigationController.PushViewController (new NoteDetailsViewController (_viewModel, e), false);
		}

		void DeleteNote (object sender, string e)
		{
			Task.Run (() => {
				_viewModel.DeleteNote (e);
			});
		}

		public async override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			List<Note> notes = null;

			await Task.Run (() => {
				notes = _viewModel.GetNotes (Settings.UserId);
			});
			_noteSource.SDSource = notes;
			_notesTableView.Source = _noteSource;
			_notesTableView.ReloadData ();

		}

		void Refresh (object sender, EventArgs e)
		{
			Task.Run (() => {
				var notes = _viewModel.GetNotes (Settings.UserId);
				InvokeOnMainThread (() => {
					_noteSource.SDSource = notes;
					_notesTableView.ReloadData ();
					_refresher.EndRefreshing ();
				});
			});
		}


	}
}

