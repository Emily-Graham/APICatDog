using Newtonsoft.Json;

/* using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;

public class Statics
{
	public static readonly HttpClient CLIENT = new HttpClient();
}

namespace Models
{
	public class Facts
	{
		public List<Fact> data { get; set; }
		public List<Link> links { get; set; }
		public int last_page { get; set; }

		public static async Task<Facts> Page(HttpClient client, int pageNo)
		{
			var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
				{ "page", pageNo.ToString() }
			});

			var request = new HttpRequestMessage();
			request.Method = HttpMethod.Get;
			request.Content = content;
			request.RequestUri = new Uri("https://catfact.ninja/facts");


			var response = await client.SendAsync(request);
			var stream = await response.Content.ReadAsStreamAsync();
			Facts facts = await JsonSerializer.DeserializeAsync<Facts>(stream);

			return facts;
		}

		public static async Task<List<Fact>> All(HttpClient client)
		{
			var firstPage = await Facts.Page(client, 1);
			var pages = firstPage.last_page;
			List<Task<Facts>> tasks = Enumerable.Range(2, pages).Select(page => Facts.Page(client, page)).ToList();

			var results = await Task.WhenAll(tasks);
			var facts = results.SelectMany(f => f.data).ToList();

			return firstPage.data.Concat(facts).ToList();
		}
	}

	public class Link
	{
		public string url { get; set; }
		public string label { get; set; }
		public bool active { get; set; }
	}

	public class Fact
	{
		public string fact { get; set; }
		public int length { get; set; }
	}
}

public class Program
{

	public async static Task Main()
	{
		var facts = await Models.Facts.All(Statics.CLIENT);

		Action<Models.Fact> factCallback = delegate (Models.Fact fact) {
			Console.WriteLine(fact.fact);
		};

		facts.ForEach(factCallback);
	}
}*/


bool restart = true;

while (restart == true)
{
    //get valid user input

    Console.WriteLine("What animal breeds would you like to read?");
    Console.WriteLine("Enter 0 for cats.");
    Console.WriteLine("Enter 1 for dogs.");

    int userInput = Convert.ToInt32(Console.ReadLine());

    //give user feedback if incorrect
    //if valid (0, 1) select relevant API code

	// if 0, call Cat API, display cat breeds
    if (userInput == 0)
    {
        Console.WriteLine("Cat Breeds:");
		
		HttpClient httpClient = new HttpClient();
		string getUrl = "https://catfact.ninja/breeds";
		Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
		HttpResponseMessage response = httpResponse.Result;
		//Console.WriteLine(response.ToString());
		//Response Data
		HttpContent responseContent = response.Content;
		Task<string> responseData = responseContent.ReadAsStringAsync();
		string data = responseData.Result;

		dynamic deserializedData = JsonConvert.DeserializeObject<dynamic>(data);
		object breedsArray = deserializedData.data;

		//empty list that will contain breeds
		List<string> breeds = new List<string>();

		// add the breed as a string to the list of breeds
		foreach (object breedObject in breedsArray)
		{
		breeds.Add(breedObject.breeds);
		}
		

		Console.WriteLine(breeds.ToString()); //change to the list of breeds

//close connection and release resourse
httpClient.Dispose();



}
else if (userInput == 1)
{
Console.WriteLine("Dog Breeds:");
// if 1, call Dog API, display dog breeds
// arrange these into alphabetical order
}
else
{
Console.WriteLine("Please type either 0 (cats) or 1 (dogs) and press enter");
}

// Give user options to exit, or continue program (call more results)
Console.WriteLine("would you like to continue? Type y to continue and hit enter. Hit enter to exit.");
string userChoice = Console.ReadLine();
if (userChoice == "y") { restart = true; }
else if (userChoice != "y") { restart = false; }
};

//refactor sections into individual files? 
