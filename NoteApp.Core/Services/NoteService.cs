using System;
using NoteApp.Core.Providers;
using System.Collections.Generic;
using NoteApp.Core.Helpers;
using NoteApp.Core.BusinessObjects;

namespace NoteApp.Core.Services
{
	public class NoteService : INoteService
	{
		IApiProvider _apiProvider;

		public NoteService (IApiProvider apiProvider)
		{
			_apiProvider = apiProvider;
		}

		public List<Note> GetNotes ()
		{
			string url = string.Format ("{0}getNotes", Constants.APIUrl);
			var result = _apiProvider.GET<List<Note>> (url, null);

			result = result.Reverse ();
			return result;
		}

		public bool AddNote (string name, string body)
		{
			string url = string.Format ("{0}addNote?name={1}&body={2}",
				             Constants.APIUrl, name, body);
			var result = _apiProvider.GET<StatusCode> (url, null);

			if (result.Status == 200)
				return true;
			
			return false;
		}
	}
}

