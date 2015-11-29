using System;

namespace Combinado
{
	public class Location
	{
		public float Latitude { get; set; }
		public float Longitude { get; set; }
	}

	public class PurchaseOrder
	{
		public string Id { get; set; }
		public float UnitPrice { get; set; } 
		public float Quantity { get; set; }
		public DateTime Timestamp { get; set; } 
		public string Details { get; set; } 
		public Location Location { get; set; } 
		public Product Product { get; set; } 
		public Client Client { get; set; } 
	}
}

