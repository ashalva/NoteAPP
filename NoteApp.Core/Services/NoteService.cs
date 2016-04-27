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

			return result;
		}
	}
}

