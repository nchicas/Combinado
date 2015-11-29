using System;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ProductsPage : ContentPage
	{
		private Category category;
		private Subcategory subcategory;

		public ProductsPage ( Category category, Subcategory subcategory )
		{
			this.category = category;
			this.subcategory = subcategory;
			System.Diagnostics.Debug.WriteLine ( category.ToString() + " " + subcategory.ToString() );
			InitializeComponents ().ConfigureAwait(false);
		}
	}
}


