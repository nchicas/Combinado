using System;
using Newtonsoft.Json;

namespace Combinado
{
	public class Client : ICacheable
	{
		[JsonProperty("objectId")]
		public string Id { get; set; }
		public string Name { get; set; }
		public string PictureUrl { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
	}
}

