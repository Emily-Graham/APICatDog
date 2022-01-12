using Newtonsoft.Json;

bool restart = true;

while (restart == true)
{
    //get valid user input

    Console.WriteLine("Which animal breeds would you like to see?");
    Console.WriteLine($"Enter 0 for cats.{Environment.NewLine}Enter 1 for dogs.");

    int userInput = Convert.ToInt32(Console.ReadLine());

    //give user feedback if incorrect

	// if 0, call Cat API, display cat breeds
    if (userInput == 0)
    {
        Console.WriteLine($"{Environment.NewLine}\x1B[4mCat Breeds:\x1B[24m {Environment.NewLine}");
		
		HttpClient httpClient = new HttpClient();
		string getUrl = "https://catfact.ninja/breeds";
		Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
		HttpResponseMessage response = httpResponse.Result;
		//Response Data
		HttpContent responseContent = response.Content;
		Task<string> responseData = responseContent.ReadAsStringAsync();
		string data = responseData.Result;

		dynamic? deserializedData = JsonConvert.DeserializeObject<dynamic>(data);

		//empty list that will contain breeds
		List<string> catBreeds = new List<string>();

		// add the breed as a string to the list of breeds
		foreach (var breedObject in  deserializedData.data)
		{
			catBreeds.Add(breedObject.breed.ToString());
		}
		foreach (string breed in catBreeds)
		{
			Console.WriteLine($"	{breed}");
		}

		Console.WriteLine($"{Environment.NewLine}Total Breeds: {catBreeds.Count}{Environment.NewLine}");

//close connection and release resource
httpClient.Dispose();

}
// if 1, call Dog API, display dog breeds
else if (userInput == 1)
{
Console.WriteLine($"{Environment.NewLine}\x1B[4mDog Breeds:\x1B[24m{Environment.NewLine}");

		// if 1, call Dog API, display dog breeds
		// arrange these into alphabetical order
		HttpClient httpClient = new HttpClient();
		string getUrl = "https://dog.ceo/api/breeds/list";
		Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
		HttpResponseMessage response = httpResponse.Result;

		//Response Data
		HttpContent responseContent = response.Content;
		Task<string> responseData = responseContent.ReadAsStringAsync();
		string data = responseData.Result;

		dynamic? deserializedData2 = JsonConvert.DeserializeObject<dynamic>(data);

		//empty list that will contain breeds
		List<string> dogBreeds = new List<string>();

		foreach (var breedObject in  deserializedData2.message)
		{
			dogBreeds.Add(breedObject.ToString());
		}
		foreach (string breed in dogBreeds)
		{
			Console.WriteLine($"	{breed}");
		}

		Console.WriteLine($"{Environment.NewLine}Total Breeds: {dogBreeds.Count}{Environment.NewLine}");
	}
else
{
Console.WriteLine("Please type either 0 or 1 and press enter");
}

// Give user options to exit or call more results
Console.WriteLine("would you like to continue? Type y to continue and hit enter. Hit enter to exit.");
string? userChoice = Console.ReadLine();
if (userChoice == "y") { restart = true; }
else if (userChoice != "y") { restart = false; }
};

//refactor sections into individual files? 