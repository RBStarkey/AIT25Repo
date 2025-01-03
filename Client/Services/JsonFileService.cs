using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services
{
	public class JsonFileService
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<JsonFileService> _logger;

		public JsonFileService(HttpClient httpClient, ILogger<JsonFileService> logger)
		{
			_httpClient = httpClient;
			_logger = logger;
		}

		public async Task<T> GetJsonFileAsync<T>(string fileName)
		{
			string json = await _httpClient.GetStringAsync(fileName);
			if (json.Length == 0)
			{
				_logger.LogInformation("GetJsonFileAsync - The JSON file is empty.");
			}
			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}

