using System;
using System.Collections.Generic;

namespace Combinado
{
	public class ProductService : IService<Product>
	{
		#region IService implementation

		public bool Create (Product model)
		{
			throw new NotImplementedException ();
		}

		public Product Read (string id)
		{
			throw new NotImplementedException ();
		}
		public List<Product> ReadAll ()
		{
			List<Product> products = new List<Product> ();

			products.Add ( new Product() {
				Id = "1",
				Name = "Zapatos de tacón",
				ImageUrl = "http://www.kadevjo.com/firmas/nchicas.png",
				Price = 23.99f,
				Stock = 25,
				Category = Category.Shoe,
				Subcategory = Subcategory.International
			});

			products.Add ( new Product() {
				Id = "2",
				Name = "Chorys",
				ImageUrl = "http://www.kadevjo.com/firmas/nchicas.png",
				Price = 0.90f,
				Stock = 1000,
				Category = Category.Food,
				Subcategory = Subcategory.Local
			});

			products.Add ( new Product() {
				Id = "3",
				Name = "Coca Cola",
				ImageUrl = "http://www.kadevjo.com/firmas/nchicas.png",
				Price = 0.5f,
				Stock = 10000,
				Category = Category.Beverage,
				Subcategory = Subcategory.Regional
			});

			products.Add ( new Product() {
				Id = "4",
				Name = "Chaparro",
				ImageUrl = "http://www.kadevjo.com/firmas/nchicas.png",
				Price = 12.99f,
				Stock = 25,
				Category = Category.Beverage,
				Subcategory = Subcategory.Regional
			});

			return products;
		}
		public bool Update (Product model)
		{
			throw new NotImplementedException ();
		}
		public bool Delete (string id)
		{
			throw new NotImplementedException ();
		}

		#endregion
		
	}
}

