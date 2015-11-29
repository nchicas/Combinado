using System;

using Xamarin.Forms;

namespace Combinado
{
	public partial class ClientDetailPage : ContentPage
	{
		private Client client;

		public ClientDetailPage ( Client client )
		{
			this.client = client;
			InitializeComponents ();
		}
	}
}


