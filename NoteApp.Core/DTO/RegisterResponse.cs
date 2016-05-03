using System;
using Newtonsoft.Json;

namespace NoteApp.Core.DTO
{
	public class RegisterResponse : ResponseBase
	{
		[JsonPropertyAttribute ("_id")]
		public string UserId {
			get;
			set;
		}
	}
}

