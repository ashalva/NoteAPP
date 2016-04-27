using System;
using UIKit;
using Foundation;
using System.Runtime.InteropServices;
using AddressBook;
using CoreGraphics;

namespace NoteApp.Touch
{
	public class NoteCell : UITableViewCell
	{
		private UILabel _name;
		private nfloat _width, _height;

		public NoteCell (NSString cellId, nfloat width, nfloat height) : base (UITableViewCellStyle.Default, cellId)
		{
			_width = width;
			_height = height;
			_name = new UILabel ();
			_name.Frame = new CGRect (30, 0, _width, _height);
			ContentView.AddSubview (_name);
		}

		public void UpdateCell (string name)
		{
			_name.Text = name;
		}
	}
}

