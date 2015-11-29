using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Combinado
{
	public partial class ClientsPage : ContentPage
	{
		private ListView clientsList;

		private async Task InitalizeComponents()
		{
			// Primero: Creamos el Layout
			// *Cuando sólo hay un control en el Page no se usa Layout

			// Segundo: Agregamos los controles al Layout
			List<Client> clients = await ClientService.Instance.ReadAll();

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


