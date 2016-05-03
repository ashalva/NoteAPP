using System;
using NoteApp.Core.DTO;

namespace NoteApp.Core.Services
{
	public interface IUserService
	{
		UserResponse RegisterUser (string username, string password);

		UserResponse Login (string username, string password);

	}
}

