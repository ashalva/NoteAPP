using System;
using Newtonsoft.Json;

namespace NoteApp.Core.BusinessObjects
{
	public class StatusCode
	{
		[JsonPropertyAttribute ("status_code")]
		public int Status {
			get;
			set;
		}
	}
}

