using System;
using System.Collections.Generic;
using Kadevjo;
using Xamarin.Forms;

namespace Combinado
{
	public class ProductService : RestManager<ProductService,Product>
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
				return "1/classes/Product";
			}
		}

		public override async System.Threading.Tasks.Task<List<Product>> ReadAll ()
		{
			ICache cache = DependencyService.Get<ICache> ();

			// Sino estamos conectados a la red devolvemos los datos de cache
			if (!Connectivity.Plugin.CrossConnectivity.Current.IsConnected) {
				return await cache.GetObjects<Product> ();
			} 

			ParseResponse<Product> response = await Execute <ParseResponse<Product>> ( Resource );

			// Al tener nuevos datos del WS, los guardamos en cache
			if( response.Results != null && response.Results.Count > 0 ) {
				cache.InsertObjects<Product> ( response.Results );
			}

			return response.Results;
		}

		#endregion


	}
}

