using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Combinado
{
	public partial class PurchaseOrderPage : ContentPage
	{
		private Entry priceEntry;
		private Entry quantityStepper;
		private Editor detailsEditor;
		private Picker productPicker;
		private Picker clientPicker;
		private CustomButton orderButton;

		private async Task InitializeComponents()
		{
			products = await ProductService.Instance.ReadAll ();
			clients = await ClientService.Instance.ReadAll ();

			StackLayout layout = new StackLayout ();

			priceEntry = new Entry () { 
				Placeholder = "Precio",
				Keyboard = Keyboard.Numeric
			};

			layout.Children.Add ( priceEntry );

			quantityStepper = new Entry () {
				Placeholder = "Cantidad",
				Keyboard = Keyboard.Numeric
			};

			layout.Children.Add ( quantityStepper );

			detailsEditor = new Editor () {
				HeightRequest = 100,
				Text = "Detalles"
			};

			layout.Children.Add ( detailsEditor );

			productPicker = new Picker () {
				Title = "Elija un producto"
			};
			foreach( var p in products ) {
				productPicker.Items.Add ( p.Name );
			}
			layout.Children.Add ( productPicker );

			clientPicker = new Picker () { 
				Title = "Elija un cliente"
			};
			foreach( var c in clients ) {
				clientPicker.Items.Add ( c.Name );
			}
			layout.Children.Add ( clientPicker );

			orderButton = new CustomButton () { 
				Text = "Enviar",
				BackgroundImage = "blue-button-hi.png"
			};

			layout.Children.Add ( orderButton );

			Content = layout;

			orderButton.Clicked += OrderButton_Clicked;
		}
	}
}


