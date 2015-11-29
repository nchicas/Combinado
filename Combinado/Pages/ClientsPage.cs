using System;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ClientsPage : ContentPage
	{
		public ClientsPage ()
		{
			Title = "Clientes";
			InitalizeComponents ().ConfigureAwait(false);
		}

		void ClientsList_ItemTapped (object sender, ItemTappedEventArgs e)
		{
			Client client = (Client)e.Item;
			Navigation.PushAsync ( new ClientDetailPage(client) );
		}
	}
}


