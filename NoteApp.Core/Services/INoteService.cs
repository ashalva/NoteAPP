﻿using System;
using System.Collections.Generic;
using NoteApp.Core.BusinessObjects;

namespace NoteApp.Core.Services
{
	public interface INoteService
	{
		List<Note> GetNotes ();

		bool AddNote (string name, string body);

		bool DeleteNote (string id);

		bool UpdateNote (string id, string newName, string newBody);
	}
}

