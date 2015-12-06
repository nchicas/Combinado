using System;
using Newtonsoft.Json;

namespace Combinado
{
	public class Location
	{
		[JsonProperty("lat")]
		public float Latitude { get; set; }
		[JsonProperty("lng")]
		public float Longitude { get; set; }
	}

	public class PurchaseOrder : ICacheable
	{
		public string Id { get; set; }
		[JsonProperty("unit_price")]
		public float UnitPrice { get; set; }
		[JsonProperty("quantity")]
		public float Quantity { get; set; }
		//[JsonProperty("timestamp")]
		public DateTime Timestamp { get; set; } 
		[JsonProperty("details")]
		public string Details { get; set; } 
		[JsonProperty("location")]
		public Location Location { get; set; } 
		[JsonProperty("product")]
		public Product Product { get; set; } 
		[JsonProperty("client")]
		public Client Client { get; set; } 
	}
}

