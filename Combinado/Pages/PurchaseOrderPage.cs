using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Combinado
{
	public partial class PurchaseOrderPage : ContentPage
	{
		private List<Product> products;
		private List<Client> clients;

		public PurchaseOrderPage ()
		{
			Title = "Pedido";
			InitializeComponents ().ConfigureAwait(false);
		}

		void OrderButton_Clicked (object sender, EventArgs e)
		{
			
		}
	}
}


