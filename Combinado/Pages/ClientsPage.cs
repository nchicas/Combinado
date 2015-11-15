using System;

using Xamarin.Forms;

namespace Combinado
{
	public class ClientsPage : ContentPage
	{
		public ClientsPage ()
		{
			Title = "Clientes";
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello Clients" }
				}
			};
		}
	}
}


