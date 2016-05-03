using System;
using NoteApp.Core.Services;
using NoteApp.Core.DTO;

namespace NoteApp.Core.ViewModels
{
	public class LoginViewModel
	{
		private IUserService _userService;

		public LoginViewModel (IUserService userService)
		{
			_userService = userService;
		}

		public UserResponse Login (string username, string password)
		{
			return _userService.Login (username, password);
		}
	}
}

