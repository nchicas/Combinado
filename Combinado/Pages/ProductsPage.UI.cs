using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Combinado
{
	public partial class ProductsPage : ContentPage
	{
		private ListView productsList;

		private async Task InitializeComponents ()
		{
			// Primero: Creamos el Layout
			// *Cuando sólo hay un control en el Page no se usa Layout

			// Segundo: Agregamos los controles al Layout
			List<Product> products = await ProductService.Instance.ReadAll();
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


