using System;
using UIKit;
using NoteApp.Core.ViewModels;
using CoreGraphics;

namespace NoteApp.Touch.Controllers
{
	public class AddNoteViewController : BaseViewController
	{
		NoteViewModel _viewModel;

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
			nfloat startY = 0;//GetStatusBarHeight ();

			nfloat padding	= 15;
			UITextField nameTextField = new UITextField ();
			nameTextField.Frame = new CGRect (padding, startY + padding, View.Frame.Width - padding * 2, 40);
			nameTextField.Placeholder = "Name";


			UITextField bodyTextField = new UITextField ();
			bodyTextField.Frame = new CGRect (padding, nameTextField.Frame.Bottom + padding, View.Frame.Width - padding * 2, 40);
			bodyTextField.Placeholder = "Body";

			View.AddSubview	(nameTextField);
			View.AddSubview (bodyTextField);

			this.NavigationItem.SetRightBarButtonItem (
				new UIBarButtonItem (UIBarButtonSystemItem.Save, (sender, args) => {
					NavigationController.PopViewController (true);
				})
				, true);
		}
	}
}

