using System;
using UIKit;
using CoreGraphics;

namespace NoteApp.Touch.Controllers
{
	public class LoginViewController : UIViewController
	{
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

			UITextField userName = new UITextField ();
			userName.Frame = new CGRect (PADDING, View.Frame.Height / 2, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			userName.Placeholder = "Username";
			userName.TextAlignment = UITextAlignment.Center;
			userName.Layer.BorderWidth = 0.5f;
			userName.Layer.BorderColor = UIColor.LightGray.CGColor;

			UITextField password = new UITextField ();
			password.Frame = new CGRect (PADDING, userName.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			password.Placeholder = "Password";
			password.SecureTextEntry = true;
			password.TextAlignment = UITextAlignment.Center;
			password.Layer.BorderWidth = 0.5f;
			password.Layer.BorderColor = UIColor.LightGray.CGColor;

			UIButton loginButton = new UIButton (UIButtonType.System);
			loginButton.SetTitle ("Login", UIControlState.Normal);
			loginButton.Frame = new CGRect (PADDING, password.Frame.Bottom + 5f, View.Frame.Width - PADDING * 2, TEXTVIEW_HEIGHT);
			loginButton.Layer.BorderWidth = 0.5f;
			loginButton.Layer.BorderColor = UIColor.LightGray.CGColor;

			View.AddSubview (userName);
			View.AddSubview (password);
			View.AddSubview (loginButton);

		}
	}
}

