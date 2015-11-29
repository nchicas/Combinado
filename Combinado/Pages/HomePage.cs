using System;

using Xamarin.Forms;

namespace Combinado
{
	public class HomePage : TabbedPage
	{
		public HomePage ()
		{
			// El titulo (Title) e icono (Icon) del Page lo toma el Page
			// padre para mostrarlo como texto
			Title = "Combinado";
			Children.Add ( new CategoriesPage() );
			Children.Add ( new ClientsPage() );
			Children.Add ( new PurchaseOrderPage() );
		}
	}
}


