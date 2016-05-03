using System;

namespace NoteApp.Core.Services
{
	public interface IUserService
	{
		bool RegisterUser (string username, string password);

		bool Login (string username, string password);

	}
}

