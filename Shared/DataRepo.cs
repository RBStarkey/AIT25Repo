using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BlazorApp.Shared
{
	public class DataRepo
	{
		public List<Person> PersonList { get; set; } = new List<Person>();
		public List<Contact> ContactList { get; set; } = new List<Contact>();
		public List<BoyAndGirl> BoyAndGirlList { get; set; } = new List<BoyAndGirl>();

		private static readonly HttpClient Client = new HttpClient();
		public async Task LoadPersonList(string URLString)
		{
			HttpResponseMessage response = await Client.GetAsync(URLString);
			if(!response.IsSuccessStatusCode)
			{
				return;
			}
			PersonList = JsonConvert.DeserializeObject<List<Person>>(response.ToString());
		}
		public async Task LoadContactList(string Filename)
		{
			try
			{
				string temp = "https://localhost:7154/JsonFiles/" + Filename;

				var json = await Client.GetStringAsync(temp);
				ContactList = JsonConvert.DeserializeObject<List<Contact>>(json);
			}
			catch (HttpRequestException reqEx)
			{
				Console.WriteLine("LoadContactList - Request Exception: " + reqEx.Message);

			}
			catch (Exception ex)
			{
				Console.WriteLine("LoadContactList - Exception: " + ex.Message);
			}
		}

	public async Task LoadBoyAndGirlList()
	{
		var response = await Client.GetAsync("https://localhost:7071/api/GetBlobFile?key=Data/BoysAndGirls.json");
		//string json = File.ReadAllText("AIT2024/Client/wwwroot/Data/Contacts90.json");
		BoyAndGirlList = JsonConvert.DeserializeObject<List<BoyAndGirl>>(response.ToString());
	}
	}
}
