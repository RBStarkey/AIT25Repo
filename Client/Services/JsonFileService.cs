using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
	public class JsonFileService
	{
		private readonly HttpClient _httpClient;

		public JsonFileService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<T> GetJsonFileAsync<T>(string fileName)
		{
			var json = await _httpClient.GetStringAsync(fileName);
			return JsonSerializer.Deserialize<T>(json);
		}
	}
}

