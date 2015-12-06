using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace Kadevjo
{
	public abstract class RestManager<I,T> : IService<T> where I : new()
	{
		private static I instance;
		public static I Instance {
			get { 
				if( instance == null ) {
					instance = new I ();
				}

				return instance;
			}
		}

		private RestClient client;
		private RestClient Client {
			get { 
				if( client == null ) {
					client = new RestClient ( BaseUrl );

					if( Headers != null && Headers.Count > 0 ) {
						foreach( var header in Headers ) {
							client.AddDefaultParameter ( 
								header.Key, 
								header.Value, 
								ParameterType.HttpHeader 
							);
						}
					}
				}

				return client;
			}
		}

		protected abstract string BaseUrl { get; }
		protected abstract Dictionary<string,string> Headers { get; }
		protected abstract string Resource { get; }

		#region IService implementation

		public async Task<bool> Create (T entity)
		{
			return await Execute<T> ( Resource, Method.POST, entity );
		}

		public async Task<T> Read (string id)
		{
			string resource = Resource + "/" + id;
			return await Execute<T> (resource);
		}

		public virtual async Task<List<T>> ReadAll ()
		{
			return await Execute<List<T>> (Resource);
		}

		public async Task<List<T>> ReadAll (IQuery query)
		{
			return await Execute<List<T>> ( Resource, query );
		}

		public async Task<bool> Update (T entity)
		{
			return await Execute<T> ( Resource, Method.PUT, entity );
		}

		public async Task<bool> Delete (string id)
		{
			string resource = Resource + "/" + id;
			return await Execute<T> ( resource, Method.DELETE );
		}

		public async Task<R> Execute<R> (string resource, IQuery query = null)
		{
			RestRequest request = new RestRequest ( resource, Method.GET );

			if ( query != null && query.Parameters != null && query.Parameters.Count > 0 ) {
				foreach (var param in query.Parameters) {
					request.AddParameter (
						param.Key, 
						param.Value, 
						ParameterType.GetOrPost
					);
				}
			}

			try {
				var response = await Client.Execute<R>( request );

				if( response.StatusCode == HttpStatusCode.OK ) {
					return response.Data;
				}
				else {
					return default( R );
				}
			}
			catch ( Exception e ) {
				Debug.WriteLine ( e.Message );
				return default( R );
			}
		}

		public async Task<bool> Execute<R>( string resource, Method method, R body = default(R) ) 
		{
			RestRequest request = new RestRequest ( resource, method );

			if (body != null) {
				request.AddBody (body);
			}

			try {
				var response = await Client.Execute( request );

				if( response.StatusCode == HttpStatusCode.OK ||
					response.StatusCode == HttpStatusCode.Created ) {
					return true;
				}
				else {
					return false;
				}
			}
			catch ( Exception e ) {
				Debug.WriteLine ( e.Message );
				return false;
			}
		}

		#endregion
	}
}

