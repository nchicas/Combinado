using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp.Portable;

namespace Kadevjo
{
	public interface IQuery
	{
		Dictionary<string,object> Parameters { get; }

		IQuery Add ( string property, object value );
		IQuery Equal ( string property, object value );
		IQuery NotEqual ( string property, object value );
		IQuery GreaterThan ( string property, object value );
		IQuery GreaterThanOrEqual ( string property, object value );
		IQuery LowerThan ( string property, object value );
		IQuery LowerThanOrEqual ( string property, object value );
		IQuery ContainedIn ( string property, object value );
		IQuery NotContainedIn ( string property, object value );
		IQuery Skip ( int value );
		IQuery Limit ( int value );
		IQuery OrderBy ( string property );
		IQuery OrderByDescending ( string property );
	}

	public interface IService<T>
	{
		Task<bool> Create( T entity );
		Task<T> Read ( string id );
		Task<List<T>> ReadAll ();
		Task<List<T>> ReadAll ( IQuery query );
		Task<bool> Update ( T entity );
		Task<bool> Delete ( string id );

		// Generic GET, R = Response
		Task<R> Execute<R> ( string resource, IQuery query );

		// Generic VERB, R = Request
		Task<bool> Execute<R> ( string resource, Method method, R body );
	}
}

