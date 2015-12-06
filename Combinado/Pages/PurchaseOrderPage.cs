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

		async void OrderButton_Clicked (object sender, EventArgs e)
		{
			PurchaseOrder order = new PurchaseOrder () {
				UnitPrice = float.Parse(priceEntry.Text),
				Quantity = float.Parse(quantityStepper.Text),
				Details = detailsEditor.Text,
				Timestamp = DateTime.Now
			};

			order.Product = products[ productPicker.SelectedIndex ];
			order.Client = clients [clientPicker.SelectedIndex];

			// Falta agregar location con una Dependency
			bool result = await PurchaseOrderService.Instance.Create( order );
			if( result ) {
				await DisplayAlert ("Combinado", "Orden agregada", "OK");
				Navigation.PopAsync ();
			}
			else {
				DisplayAlert ("Combinado", "Error", "OK");
			}
		}
	}
}

