using System;

namespace NoteApp.Core.Services
{
	public interface IUserService
	{
		public bool RegisterUser(string name, string password);
	}
}

