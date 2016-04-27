using System;
using UIKit;
using NoteApp.Core.ViewModels;
using CoreGraphics;
using NoteApp.Touch.Helpers;
using System.Threading.Tasks;
using NoteApp.Core.BusinessObjects;

namespace NoteApp.Touch.Controllers
{
	public class NoteDetailsViewController : BaseViewController
	{
		private NoteViewModel _viewModel;
		private UIActivityIndicatorView _dialog;
		private Note _note;

		public NoteDetailsViewController (NoteViewModel viewModel, Note note) : base ()
		{
			_viewModel = viewModel;
			_note = note;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Title = "Note Details";
			View.BackgroundColor = UIColor.White;
			InitUI ();
		}

		private void InitUI ()
		{
			nfloat startY = GetStatusBarHeight ();

			nfloat padding	= 10;
			UITextField nameTextField = new UITextField ();
			nameTextField.Frame = new CGRect (padding, padding, View.Frame.Width - padding * 2, 40);
			nameTextField.Placeholder = "Name";
			nameTextField.Text = _note.Name;
			nameTextField.Layer.BorderWidth = 1f;
			nameTextField.Layer.BorderColor = UIColor.LightGray.CGColor;
			nameTextField.LeftViewMode = UITextFieldViewMode.Always;
			nameTextField.LeftView = new UIView (new CGRect (0, 0, padding, 40));

			UITextView bodyTextField = new UITextView ();
			bodyTextField.Text = _note.Body;
			bodyTextField.Frame = new CGRect (padding, 
				nameTextField.Frame.Bottom + padding,
				View.Frame.Width - padding * 2, 
				View.Frame.Height - (nameTextField.Frame.Bottom + padding * 2 + startY));
			bodyTextField.Layer.BorderWidth = 1f;
			bodyTextField.Layer.BorderColor = UIColor.LightGray.CGColor;


			View.AddSubview	(nameTextField);
			View.AddSubview (bodyTextField);

			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (UIBarButtonSystemItem.Save, (sender, args) => {
					if (string.IsNullOrEmpty (nameTextField.Text) || string.IsNullOrEmpty (bodyTextField.Text)) {
						UIAlertController alertcontroller = new UIAlertController ();
						alertcontroller.Message = "Please enter note Name and Body";
						alertcontroller.Title = "Error";
						alertcontroller.AddAction (UIAlertAction.Create ("OK", UIAlertActionStyle.Default, null));
						PresentViewController (alertcontroller, true, null);
					} else {
						_dialog = DialogHelper.ShowProgressDialog (View.Frame, View);
						UpdateNote (nameTextField.Text, bodyTextField.Text);
					}
				})
				, true);
		}

		private async void UpdateNote (string name, string body)
		{
			bool success = false;
			await Task.Run (() => {
				success = _viewModel.UpdateNote (_note.NoteId, name, body);
			});
			if (success) {
				NavigationController.PopViewController (true);
			}
			DialogHelper.DismissProgressDialog (_dialog);
		}

	}
}

