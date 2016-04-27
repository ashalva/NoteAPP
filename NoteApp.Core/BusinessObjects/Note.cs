using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace NoteApp.Core.BusinessObjects
{
	public class Note
	{
		[JsonPropertyAttribute ("_id")]
		public string NoteId { get; set; }

		[JsonPropertyAttribute ("name")]
		public string Name { get; set; }

		[JsonPropertyAttribute ("body")]
		public string Body { get; set; }
	}
}

