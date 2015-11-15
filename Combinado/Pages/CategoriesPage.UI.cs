using System;

using Xamarin.Forms;

namespace Combinado
{
	public partial class CategoriesPage : ContentPage
	{
		private TableView categoriesTable;

		private Category[] categories = new Category[] {
			Category.Food,
			Category.Beverage,
			Category.Cloth,
			Category.Shoe,
			Category.Toy,
			Category.Pet,
			Category.Other
		};

		private Subcategory[] subcategories = new Subcategory[] {
			Subcategory.Local,
			Subcategory.Regional,
			Subcategory.International
		};

		private void InitializeComponents()
		{
			// Primero: Creamos el Layout
			// *Cuando sólo hay un control en el Page no se usa Layout

			// Segundo: Agregamos los controles al Layout
			categoriesTable = new TableView();
			TableRoot tableRoot = new TableRoot ("Categorías");
			categoriesTable.Root = tableRoot;
			categoriesTable.HasUnevenRows = true;
			categoriesTable.Intent = TableIntent.Data;

			foreach( Category category in categories ) {
				TableSection section = new TableSection ( category.ToString() );
				foreach( Subcategory subcategory in subcategories ) {
					TextCell cell = new TextCell ();
					cell.Text = subcategory.ToString ();
					cell.Detail = "Prueba";
					cell.Tapped += (object sender, EventArgs e) => {
						Navigation.PushAsync( 
							new ProductsPage( category, subcategory ) 
						);
					};
					section.Add ( cell );
				}
				tableRoot.Add ( section );
			}

			// Tercero: Asignamos el Layout como contenido del Page
			Content = categoriesTable;
		}
	}
}
	