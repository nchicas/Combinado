using System;
using System.Collections.Generic;

namespace Combinado
{
	public class ClientService : IService<Client>
	{
		#region IService implementation

		public bool Create (Client model)
		{
			throw new NotImplementedException ();
		}

		public Client Read (string id)
		{
			throw new NotImplementedException ();
		}

		public List<Client> ReadAll ()
		{
			List<Client> clients = new List<Client> ();

			clients.Add ( new Client() {
				Name = "Pedro Perez",
				Phone = "2222-2222",
				PictureUrl = "http://www.kadevjo.com/firmas/nchicas.png"
			});

			clients.Add ( new Client() {
				Name = "Pablo Escobar",
				Phone = "2234-3455",
				PictureUrl = "http://www.kadevjo.com/firmas/nchicas.png"
			});

			clients.Add ( new Client() {
				Name = "Ronaldinho Gaucho",
				Phone = "2222-2222",
				PictureUrl = "http://www.kadevjo.com/firmas/nchicas.png"
			});

			clients.Add ( new Client() {
				Name = "Paco Flores",
				Phone = "4656-4566",
				PictureUrl = "http://www.kadevjo.com/firmas/nchicas.png"
			});

			return clients;
		}

		public bool Update (Client model)
		{
			throw new NotImplementedException ();
		}

		public bool Delete (string id)
		{
			throw new NotImplementedException ();
		}

		#endregion
	}
}

