using System;
using UIKit;
using NoteApp.Touch.Helpers;
using NoteApp.Core.ViewModels;
using Autofac;
using CoreGraphics;
using System.Threading.Tasks;

namespace NoteApp.Touch.Controllers
{
	public class RegisterViewController : UIViewController
	{
		private RegisterViewModel _viewModel;
		private UITextField _userName;
		private UITextField _password;
		private UITextField _confirmPassword;

		public RegisterViewController () : base ()
		{
			using (var scope = App.Container.BeginLifetimeScope ()) {
				_viewModel = scope.Resolve<RegisterViewModel> ();
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			View.BackgroundColor = UIColor.White;
			Title = "Register";
			InitUI ();
		}

		private void InitUI ()
		{
			nfloat PADDING = 10f;
			nfloat TEXTVIEW_HEIGHT = 40;

			_userName = new UITextField ();
			_userName.Frame = new CGRect (PADDING, 20, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			_userName.Placeholder = "Username";
			_userName.TextAlignment = UITextAlignment.Center;
			_userName.Layer.BorderWidth = 0.5f;
			_userName.Layer.BorderColor = UIColor.LightGray.CGColor;

			_password = new UITextField ();
			_password.Frame = new CGRect (PADDING, _userName.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			_password.Placeholder = "Password";
			_password.SecureTextEntry = true;
			_password.TextAlignment = UITextAlignment.Center;
			_password.Layer.BorderWidth = 0.5f;
			_password.Layer.BorderColor = UIColor.LightGray.CGColor;

			_confirmPassword = new UITextField ();
			_confirmPassword.Frame = new CGRect (PADDING, _password.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			_confirmPassword.Placeholder = "Confirm Password";
			_confirmPassword.SecureTextEntry = true;
			_confirmPassword.TextAlignment = UITextAlignment.Center;
			_confirmPassword.Layer.BorderWidth = 0.5f;
			_confirmPassword.Layer.BorderColor = UIColor.LightGray.CGColor;

			UIButton registerButton = new UIButton (UIButtonType.System);
			registerButton.SetTitle ("Login", UIControlState.Normal);
			registerButton.Frame = new CGRect (PADDING, _confirmPassword.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			registerButton.Layer.BorderWidth = 0.5f;
			registerButton.Layer.BorderColor = UIColor.LightGray.CGColor;
			registerButton.TouchUpInside += RegisterClicked;

			View.AddSubview (_userName);
			View.AddSubview (_password);
			View.AddSubview (_confirmPassword);
			View.AddSubview (registerButton);

		}

		void RegisterClicked (object sender, EventArgs e)
		{
			var dialog = DialogHelper.ShowProgressDialog (new CGRect (0, 0, View.Frame.Width, View.Frame.Height), View);
			var username = _userName.Text;
			var password = _password.Text;
			if (!string.IsNullOrEmpty (_password.Text) && !string.IsNullOrEmpty (_userName.Text) && _password.Text == _confirmPassword.Text) {
				Task.Run (() => {
					var result = _viewModel.Register (username, password);
					InvokeOnMainThread (() => {
						DialogHelper.DismissProgressDialog (dialog);
						if (result.Status == 200) {
							Settings.UserId = result.UserId;
							UIApplication.SharedApplication.KeyWindow.RootViewController = new UINavigationController (new ViewController ());
						} else {
							_password.Text = string.Empty;
							_confirmPassword.Text = string.Empty;
							_userName.Text = string.Empty;
						}
					});
				});
			} else {
				DialogHelper.DismissProgressDialog (dialog);
			}

		}
	}
}

