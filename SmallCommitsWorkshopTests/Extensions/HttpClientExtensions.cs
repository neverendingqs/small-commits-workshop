using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmallCommitsWorkshopTests.Extensions {
	public static class HttpClientExtensions {
		public static async Task<T> ReadAsJsonAsync<T>( this HttpContent content ) {
			string jsonString = await content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<T>( jsonString );
		}
	}
}
