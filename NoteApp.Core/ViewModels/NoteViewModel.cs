using System;
using NoteApp.Core.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using NoteApp.Core.BusinessObjects;

namespace NoteApp.Core.ViewModels
{
	public class NoteViewModel
	{
		private INoteService _noteServices;

		public NoteViewModel (INoteService noteService)
		{
			_noteServices = noteService;
		}

		public List<Note> GetNotes ()
		{
			return _noteServices.GetNotes ();
		}

		public bool AddNote (string name, string body)
		{
			return _noteServices.AddNote (name, body);
		}

		public bool DeleteNote (string id)
		{
			return _noteServices.DeleteNote (id);
		}

		public bool UpdateNote (string id, string newName, string newBody)
		{
			return _noteServices.UpdateNote (id, newName, newBody);
		}
	}
}

