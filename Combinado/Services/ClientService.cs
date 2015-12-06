using System;
using System.Collections.Generic;
using Kadevjo;
using Xamarin.Forms;

namespace Combinado
{
	public class ClientService : RestManager<ClientService,Client>
	{
		#region implemented abstract members of RestManager

		protected override string BaseUrl {
			get {
				return "https://api.parse.com/";
			}
		}

		protected override Dictionary<string, string> Headers {
			get {
				return new Dictionary<string,string> () { 
					{ "X-Parse-Application-Id", "UJBDejGLZAX85aHNdQSO0sRAba8mWDRxLUFSg05Q" },
					{ "X-Parse-REST-API-Key", "esywSuWhSi8bVoXrnem980emUdCw9d6SMqCL5Q7D" }
				};
			}
		}

		protected override string Resource {
			get {
				return "1/classes/Client";
			}
		}

		public override async System.Threading.Tasks.Task<List<Client>> ReadAll ()
		{
			ICache cache = DependencyService.Get<ICache> ();

			// Sino estamos conectados a la red devolvemos los datos de cache
			if (!Connectivity.Plugin.CrossConnectivity.Current.IsConnected) {
				return await cache.GetObjects<Client> ();
			} 

			ParseResponse<Client> response = await Execute <ParseResponse<Client>> ( Resource );

			// Al tener nuevos datos del WS, los guardamos en cache
			if( response.Results != null && response.Results.Count > 0 ) {
				cache.InsertObjects<Client> ( response.Results );
			}

			return response.Results;
		}

		#endregion


	}
}

