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
		private UITableView _notes;
		private UIActivityIndicatorView _dialog;

		public ViewController () : base ()
		{
			using (var scope = App.Container.BeginLifetimeScope ()) {
				_viewModel = scope.Resolve<NoteViewModel> ();
			}
		}


		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_dialog = DialogHelper.ShowProgressDialog (View.Frame, View);

			Title = "My Notes";
			View.BackgroundColor = UIColor.White;

			NavigationController.NavigationBar.Translucent = false;

			InitUI ();
		}

		private async void InitUI ()
		{
			nfloat startY = 0;//GetStatusBarHeight ();
			_notes = new UITableView (new CGRect (0, startY, View.Frame.Width, View.Frame.Height - startY));
			_notes.RowHeight = 70;
			List<Note> notes = null;
			await Task.Run (() => {
				notes = _viewModel.GetNotes ();
			});

			_notes.DataSource = new NotesTableSource (notes, View.Frame.Width, 70);
			_notes.ReloadData ();

			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (UIBarButtonSystemItem.Add, (sender, args) => {
					NavigationController.PushViewController (new AddNoteViewController (_viewModel), false);
				})
				, true);



			View.AddSubview (_notes);
			DialogHelper.DismissProgressDialog (_dialog);
		}


	}
}

