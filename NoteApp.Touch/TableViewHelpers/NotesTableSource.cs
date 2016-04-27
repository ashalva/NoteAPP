using System;
using UIKit;
using System.Collections.Generic;
using AVFoundation;
using NoteApp.Core.BusinessObjects;
using Foundation;

namespace NoteApp.Touch
{
	public class NotesTableSource : UITableViewDataSource
	{
		public List<Note> SDSource{ get; set; }

		private NSString _cellIdentifier = new NSString ("NoteCell");
		private nfloat _width, _height;

		public NotesTableSource (List<Note> source, nfloat width, nfloat height)
		{
			SDSource = source;
			_width = width;
			_height = height;
		}


		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			NoteCell cell = (NoteCell)tableView.DequeueReusableCell (_cellIdentifier);
			if (cell == null) {
				cell = new NoteCell (_cellIdentifier, _width, _height);
			}
			var item = SDSource [indexPath.Row];
			cell.UpdateCell (item.Name);
			return cell;
		}

		public override nint RowsInSection (UITableView tableView, nint section)
		{
			if (SDSource != null)
				return SDSource.Count;
			else
				return 0;
		}


	}
}

