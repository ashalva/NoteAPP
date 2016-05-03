using System;
using NoteApp.Core.Services;
using System.ServiceModel.Security.Tokens;

namespace NoteApp.Core.ViewModels
{
	public class RegisterViewModel
	{
		private IUserService _userService;

		public RegisterViewModel (IUserService userService)
		{
			_userService = userService;
		}

		public bool Register (string usernName, string password)
		{
			return _userService.RegisterUser (usernName, password);
		}
	}
}

