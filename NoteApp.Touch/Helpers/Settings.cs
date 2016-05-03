using System;
using Foundation;

namespace NoteApp.Touch.Helpers
{
	public static class Settings
	{
		public static string UserId {
			get { 
				string value = NSUserDefaults.StandardUserDefaults.StringForKey (Constants.UserId); 
				if (string.IsNullOrWhiteSpace (value))
					return value;
				else
					return string.Empty;
			}
			set {				
				NSUserDefaults.StandardUserDefaults.SetString (value, Constants.UserId); 
				NSUserDefaults.StandardUserDefaults.Synchronize ();
			}
		}
	}
}

