using System;
using System.Collections.Generic;

namespace Combinado
{
	public interface IService<T>
	{
		bool Create ( T model );
		T Read ( string id );
		List<T> ReadAll ();
		bool Update ( T model );
		bool Delete ( string id );
	}
}

