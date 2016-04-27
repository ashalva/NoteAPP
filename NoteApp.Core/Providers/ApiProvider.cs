using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NoteApp.Core.Providers
{
	public class ApiProvider : IApiProvider
	{
		private HttpClient _httpClient;

		public ApiProvider ()
		{
			_httpClient = new HttpClient ();
			_httpClient.Timeout = TimeSpan.FromMilliseconds (30000);
		}

		#region IApiProvider implementation

		public TResultObject GET<TResultObject> (string url, Dictionary<string, string> headers)
		{
			lock (_httpClient) {       

				if (headers != null && headers.Count > 0) {
					foreach (var header in headers) {
						_httpClient.DefaultRequestHeaders.Add (header.Key, header.Value);
					}
				}
				var getResult = _httpClient.GetAsync (url).Result;
				if (getResult.IsSuccessStatusCode) {
					var contentString = getResult.Content.ReadAsStringAsync ().Result;
					var contentObject = JsonConvert.DeserializeObject<TResultObject> (contentString);
					return contentObject;
				} else {
					throw new Exception ("Result Wasn't Successfull");
				}
			}
		}

		#endregion
	}
}

