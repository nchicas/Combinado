using System.Collections.Generic;
using System.Threading.Tasks;

namespace Combinado
{
	public interface ICache
	{
		Task<List<T>> GetObjects<T> () where T : ICacheable;
		Task<T> GetObject<T> (string key) where T : ICacheable;
		Task InsertObjects<T> (List<T> objects) where T : ICacheable;
		Task InsertObject<T> (T value) where T : ICacheable;
		Task RemoveObjects<T> () where T : ICacheable;
		Task RemoveObject<T> (string key) where T : ICacheable;
		Task<string> LoadImage (string url);
	}
}

