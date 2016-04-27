using System;
using UIKit;
using NoteApp.Core.ViewModels;
using CoreGraphics;
using NoteApp.Touch.Helpers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace NoteApp.Touch.Controllers
{
	public class AddNoteViewController : BaseViewController
	{
		private NoteViewModel _viewModel;
		private UIActivityIndicatorView _dialog;

		public AddNoteViewController (NoteViewModel noteViewModel) : base ()
		{
			_viewModel = noteViewModel;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			Title = "Add Note";
			InitUI ();
		}

		private void InitUI ()
		{
			nfloat startY = 0; //GetStatusBarHeight ();

			nfloat padding	= 15;
			UITextField nameTextField = new UITextField ();
			nameTextField.Frame = new CGRect (padding, startY + padding, View.Frame.Width - padding * 2, 40);
			nameTextField.Placeholder = "Name";


			UITextView bodyTextField = new UITextView ();
			bodyTextField.Frame = new CGRect (padding, 
				nameTextField.Frame.Bottom + padding,
				View.Frame.Width - padding * 2, 
				View.Frame.Height - (nameTextField.Frame.Bottom + padding * 2));
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
						PresentViewController (alertcontroller, true, null);
					} else {
						_dialog = DialogHelper.ShowProgressDialog (View.Frame, View);
						Addnote (nameTextField.Text, bodyTextField.Text);
					}
				})
				, true);
		}

		private async void Addnote (string name, string body)
		{
			bool success = false;
			await Task.Run (() => {
				success = _viewModel.AddNote (name, body);
			});
			if (success) {
				NavigationController.PopViewController (true);
			}
			DialogHelper.DismissProgressDialog (_dialog);
		}
	}
}

