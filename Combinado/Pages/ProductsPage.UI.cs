using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ProductsPage : ContentPage
	{
		private ListView productsList;

		private void InitializeComponents ()
		{
			// Primero: Creamos el Layout
			// *Cuando sólo hay un control en el Page no se usa Layout

			// Segundo: Agregamos los controles al Layout
			ProductService service = new ProductService();
			List<Product> products = service.ReadAll ();
			var data = products.Where ( 
				p => p.Category == category && 
				p.Subcategory == subcategory 
			);

			productsList = new ListView () {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(ProductCell)),
				ItemsSource = data
			};

			// Tercero: Asignamos el Layout como contenido del Page
			Content = productsList;
		}
	}
}


