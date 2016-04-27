using System;
using UIKit;

namespace NoteApp.Touch.Controllers
{
	public class BaseViewController : UIViewController
	{
		public BaseViewController ()
		{
		}

		protected nfloat GetStatusBarHeight ()
		{
			nfloat statusBarInfoHeight = UIApplication.SharedApplication.StatusBarFrame.Height;			
			if (statusBarInfoHeight < 20) {
				statusBarInfoHeight = 20;
			}
			if (NavigationController != null)
				return (statusBarInfoHeight + NavigationController.NavigationBar.Frame.Height);
			else
				return 0;
		}
	}
}

