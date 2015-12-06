using System;
using Newtonsoft.Json;

namespace Combinado
{
	public enum Category 
	{
		Food,
		Beverage,
		Cloth,
		Toy,
		Pet,
		Shoe,
		Other
	}

	public enum Subcategory
	{
		Local,
		Regional,
		International
	}

	public class Product : ICacheable
	{
		[JsonProperty("objectId")]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public string ImageUrl { get; set; }
		public float Stock { get; set; }
		public Category Category { get; set; }
		public Subcategory Subcategory { get; set; }
	}
}

