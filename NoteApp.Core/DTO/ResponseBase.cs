using System;
using Newtonsoft.Json;

namespace NoteApp.Core.DTO
{
	public class ResponseBase
	{
		[JsonPropertyAttribute ("status_code")]
		public int Status {
			get;
			set;
		}
	}
}

