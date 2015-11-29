using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ClientsPage : ContentPage
	{
		private ListView clientsList;

		private void InitalizeComponents()
		{
			// Primero: Creamos el Layout
			// *Cuando sólo hay un control en el Page no se usa Layout

			// Segundo: Agregamos los controles al Layout
			ClientService service = new ClientService();
			List<Client> clients = service.ReadAll ();

			clientsList = new ListView () {
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(typeof(ClientCell)),
				ItemsSource = clients
			};

			// Tercero: Asignamos el Layout como contenido del Page
			Content = clientsList;

			clientsList.ItemTapped += ClientsList_ItemTapped;
		}
	}
}


