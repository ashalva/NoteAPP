using System;
using NoteApp.Core.Providers;
using NoteApp.Core.Helpers;
using NoteApp.Core.DTO;
using NoteApp.Core.BusinessObjects;

namespace NoteApp.Core.Services
{
	public class UserService : IUserService
	{
		IApiProvider _apiProvider;

		public UserService (IApiProvider apiProvider)
		{
			_apiProvider = apiProvider;
		}

		public UserResponse RegisterUser (string username, string password)
		{
			var url = string.Format ("{0}register?username={1}&password={2}", Constants.APIUrl, username, password);
			return _apiProvider.GET<UserResponse> (url, null);


		}

		public UserResponse Login (string username, string password)
		{
			var url = string.Format ("{0}login?username={1}&password={2}", Constants.APIUrl, username, password);
			return  _apiProvider.GET<UserResponse> (url, null);

		}
	}
}

