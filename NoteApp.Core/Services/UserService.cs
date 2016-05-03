using System;
using NoteApp.Core.Providers;
using NoteApp.Core.Helpers;
using NoteApp.Core.DTO;

namespace NoteApp.Core.Services
{
	public class UserService : IUserService
	{
		IApiProvider _apiProvider;

		public UserService (IApiProvider apiProvider)
		{
			_apiProvider = apiProvider;
		}

		public bool RegisterUser (string name, string password)
		{
			var url = string.Format ("{0}register?username={1}&password={2}", Constants.APIUrl, name, password);
			var result = _apiProvider.GET<RegisterResponse> (url, null);

			if (result != null && result.Status == 200)
				return true;
			
			return false;

		}
	}
}

