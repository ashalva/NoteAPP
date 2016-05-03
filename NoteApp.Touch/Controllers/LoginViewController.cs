using System;
using UIKit;
using CoreGraphics;
using NoteApp.Core.ViewModels;
using Autofac;
using System.Threading.Tasks;
using NoteApp.Touch.Helpers;

namespace NoteApp.Touch.Controllers
{
	public class LoginViewController : BaseViewController
	{
		private LoginViewModel _viewModel;
		private UITextField _userName;
		private UITextField _password;

		public LoginViewController () : base ()
		{
			using (var scope = App.Container.BeginLifetimeScope ()) {
				_viewModel = scope.Resolve<LoginViewModel> ();
			}
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			InitUI ();
		}

		private void InitUI ()
		{
			nfloat PADDING = 10f;
			nfloat TEXTVIEW_HEIGHT = 40;

			_userName = new UITextField ();
			_userName.Frame = new CGRect (PADDING, View.Frame.Height / 2, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
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

			UIButton loginButton = new UIButton (UIButtonType.System);
			loginButton.SetTitle ("Login", UIControlState.Normal);
			loginButton.Frame = new CGRect (PADDING, _password.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			loginButton.Layer.BorderWidth = 0.5f;
			loginButton.Layer.BorderColor = UIColor.LightGray.CGColor;
			loginButton.TouchUpInside += LoginClicked;

			View.AddSubview (_userName);
			View.AddSubview (_password);
			View.AddSubview (loginButton);

		}

		void LoginClicked (object sender, EventArgs e)
		{
			var dialog = DialogHelper.ShowProgressDialog (View.Frame, View);
			var username = _userName.Text;
			var password = _password.Text;
			if (!string.IsNullOrEmpty (_password.Text) && !string.IsNullOrEmpty (_userName.Text)) {
				Task.Run (() => {
					var result = _viewModel.Login (username, password);
					InvokeOnMainThread (() => {
						DialogHelper.DismissProgressDialog (dialog);
						if (result.Status == 200) {
							Settings.UserId = result.UserId;
							UIApplication.SharedApplication.KeyWindow.RootViewController = new UINavigationController (new ViewController ());
						} else {
							_password.Text = string.Empty;
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

