using System;
using System.Collections.Generic;
using Kadevjo;

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
			ParseResponse<Client> response = await Execute <ParseResponse<Client>> ( Resource );
			return response.Results;
		}

		#endregion


	}
}

