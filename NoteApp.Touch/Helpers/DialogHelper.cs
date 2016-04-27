using System;
using UIKit;
using CoreGraphics;

namespace NoteApp.Touch.Helpers
{
	public static class DialogHelper
	{
		public static UIActivityIndicatorView ShowProgressDialog (CGRect frame, UIView view)
		{
			var activityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);
			activityIndicator.BackgroundColor = UIColor.Gray;
			activityIndicator.Alpha = 0.5f;
			activityIndicator.Frame = frame;
			view.AddSubview (activityIndicator);
			activityIndicator.StartAnimating ();
			return activityIndicator;
		}

		public static void DismissProgressDialog (UIActivityIndicatorView activityIndicator)
		{
			if (activityIndicator != null) {
				activityIndicator.StopAnimating ();
				activityIndicator.RemoveFromSuperview ();
				activityIndicator.Dispose ();
				activityIndicator = null;
			}
		}
	}
}

