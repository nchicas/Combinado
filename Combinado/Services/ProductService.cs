using System;
using System.Collections.Generic;
using Kadevjo;

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
			ParseResponse<Product> response = await Execute <ParseResponse<Product>> ( Resource );
			return response.Results;
		}

		#endregion


	}
}

