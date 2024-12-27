using BlazorApp.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
	public class DataRepo
	{
		public List<Person> PersonList { get => personList; set => personList = value; }
		public List<Contact> ContactList { get; set; }
		public List<BoyAndGirl> BoyAndGirlList { get; set; }

		private static HttpClient HttpClient { get; set; }
		private List<Person> personList;

		public DataRepo()
		{
			PersonList = new List<Person>();
			ContactList = new List<Contact>();
			BoyAndGirlList = new List<BoyAndGirl>();
		}
		public async Task LoadPersonList(string URLString)
		{
			HttpResponseMessage response = await HttpClient.GetAsync(URLString);
			if(!response.IsSuccessStatusCode)
			{
				return;
			}
			PersonList = JsonConvert.DeserializeObject<List<Person>>(response.ToString());
		}
		public async Task LoadContactList(string UrlString)
		{
			try
			{
				HttpResponseMessage response = await HttpClient.GetAsync(UrlString);
				string responseBody = await response.Content.ReadAsStringAsync();
				ContactList = JsonConvert.DeserializeObject<List<Contact>>(responseBody);
			}
			catch (Exception ex)
			{
				Console.WriteLine("LoadContactList - Exception: " + ex.Message);
			}
		}

	public async Task LoadBoyAndGirlList()
	{
		var response = await HttpClient.GetAsync("https://localhost:7071/api/GetBlobFile?key=Data/BoysAndGirls.json");
		//string json = File.ReadAllText("AIT2024/Client/wwwroot/Data/Contacts90.json");
		BoyAndGirlList = JsonConvert.DeserializeObject<List<BoyAndGirl>>(response.ToString());
	}
	}
}
