using System.Threading.Tasks;
using System.Collections.Generic;
using Foundation;
using Combinado;
using Combinado.iOS;
using Akavache;
using System.Reactive.Linq;
using System.Linq;

[assembly: Xamarin.Forms.Dependency(typeof(Cache_iOS))]
namespace Combinado.iOS
{
	public class Cache_iOS : ICache
	{
		public Cache_iOS ()
		{
			BlobCache.ApplicationName = "Combinado";
		}

		public async Task<List<T>> GetObjects<T> () where T : ICacheable
		{
			IEnumerable<T> objects = await BlobCache.LocalMachine.GetAllObjects<T>();
			return objects.ToList();
		}

		public async Task<T> GetObject<T> (string key) where T : ICacheable
		{
			try {
				return await BlobCache.LocalMachine.GetObject<T>(key);
			} catch (KeyNotFoundException){
				return default(T);
			}
		}

		public async Task InsertObjects<T> (List<T> objects) where T : ICacheable
		{
			Dictionary<string,T> values = new Dictionary<string, T> ();
			foreach( var @object in objects ) {
				values.Add ( @object.Id, @object );
			}

			await BlobCache.LocalMachine.InsertObjects<T> (values);
		}

		public async Task InsertObject<T> (T @object) where T : ICacheable
		{
			await BlobCache.LocalMachine.InsertObject<T> (@object.Id, @object);
		}

		public async Task RemoveObjects<T> () where T : ICacheable
		{
			await BlobCache.LocalMachine.InvalidateAllObjects<T> ();
		}

		public async Task RemoveObject<T> (string key) where T : ICacheable
		{
			await BlobCache.LocalMachine.InvalidateObject<T>(key);
		}

		public async Task<string> LoadImage(string url)
		{
			var bitmap = await BlobCache.LocalMachine.LoadImageFromUrl ( url );
			string path = System.Environment.GetFolderPath ( System.Environment.SpecialFolder.MyDocuments );
			path += "/test.png";
			var stream = new System.IO.FileStream ( path, System.IO.FileAccess.ReadWrite );
			bitmap.Save ( Splat.CompressedBitmapFormat.Png, 1.0f, stream );
			return path;
		}
	}
}

