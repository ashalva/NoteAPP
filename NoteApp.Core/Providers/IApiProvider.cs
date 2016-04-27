using System;
using System.Collections.Generic;

namespace NoteApp.Core.Providers
{
	public interface IApiProvider
	{
		TResultObject GET<TResultObject> (string url, Dictionary<string, string> headers);

		//		TResultObject PostToApi<TResultObject> (string url, string body) where TResultObject : new();
	}
}

