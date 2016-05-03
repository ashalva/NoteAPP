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

		public List<Note> GetNotes (string userId)
		{
			string url = string.Format ("{0}getNotes?userId={1}", Constants.APIUrl, userId);
			var result = _apiProvider.GET<List<Note>> (url, null);

			if (result != null)
				result.Reverse ();
			return result;
		}

		public bool AddNote (string name, string body, string userId)
		{
			string url = string.Format ("{0}addNote?name={1}&body={2}&userId={3}",
				             Constants.APIUrl, name, body, userId);
			var result = _apiProvider.GET<StatusCode> (url, null);

			if (result.Status == 200)
				return true;
			
			return false;
		}

		public bool DeleteNote (string id)
		{
			string url = string.Format ("{0}deleteNote?id={1}",
				             Constants.APIUrl, id);
			var result = _apiProvider.GET<StatusCode> (url, null);

			if (result.Status == 200)
				return true;

			return false;
		}

		public bool UpdateNote (string id, string newName, string newBody)
		{
			string url = string.Format ("{0}updateNote?id={1}&name={2}&body={3}",
				             Constants.APIUrl, id, newName, newBody);
			var result = _apiProvider.GET<StatusCode> (url, null);

			if (result.Status == 200)
				return true;

			return false;
		}
	}
}

