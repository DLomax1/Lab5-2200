using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Lab5FinalTest;
class Program
{
    static async Task Main()
    {
        while (true)
        {
            Console.WriteLine("Rick and Morty Info Viewer");
            Console.WriteLine("1. View character information");
            Console.WriteLine("2. View episode information");
            Console.WriteLine("3. View location information");
            Console.WriteLine("4. View multiple characters");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ViewCharacterInformation();
                    break;
                case "2":
                    await ViewEpisodeInformation();
                    break;
                case "3":
                    await ViewLocationInformation();
                    break;
                case "4":
                    await ViewMultipleCharacters();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    static async Task ViewMultipleCharacters()
    {
        Console.WriteLine("Enter character IDs separated by spaces:");
        string input = Console.ReadLine();
        List<int> characterIds = input.Split(' ').Select(int.Parse).ToList();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                foreach (int characterId in characterIds)
                {
                    HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character/{characterId}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        JObject characterData = JObject.Parse(responseBody);
                        string name = characterData["name"].ToString();
                        string species = characterData["species"].ToString();
                        string status = characterData["status"].ToString();
                        string origin = characterData["origin"]["name"].ToString();

                        
                        Console.WriteLine($"Character ID: {characterId}");
                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Species: {species}");
                        Console.WriteLine($"Status: {status}");
                        Console.WriteLine($"Origin: {origin}");
                        Console.WriteLine("----------");
                    }
                    else
                    {
                        Console.WriteLine($"Error for Character ID {characterId}: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    static async Task ViewCharacterInformation()
    {
        Console.Write("Enter character ID: ");
        if (!int.TryParse(Console.ReadLine(), out int characterId) || characterId <= 0)
        {
            Console.WriteLine("Invalid character ID. Please enter a positive integer.");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/character/{characterId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject characterData = JObject.Parse(responseBody);

                    Console.WriteLine("----------");
                    Console.WriteLine("Character Information:");
                    Console.WriteLine($"Name: {characterData["name"]}");
                    Console.WriteLine($"Species: {characterData["species"]}");
                    Console.WriteLine($"Status: {characterData["status"]}");
                    Console.WriteLine($"Origin: {characterData["origin"]["name"]}");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static async Task ViewEpisodeInformation()
    {
        Console.Write("Enter episode ID: ");
        if (!int.TryParse(Console.ReadLine(), out int episodeId) || episodeId <= 0)
        {
            Console.WriteLine("Invalid episode ID. Please enter a positive integer.");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/episode/{episodeId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject episodeData = JObject.Parse(responseBody);

                    Console.WriteLine("----------");
                    Console.WriteLine("Episode Information:");
                    Console.WriteLine($"Name: {episodeData["name"]}");
                    Console.WriteLine($"Air Date: {episodeData["air_date"]}");
                    Console.WriteLine($"Episode Code: {episodeData["episode"]}");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static async Task ViewLocationInformation()
    {
        Console.Write("Enter location ID: ");
        if (!int.TryParse(Console.ReadLine(), out int locationId) || locationId <= 0)
        {
            Console.WriteLine("Invalid location ID. Please enter a positive integer.");
            return;
        }

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://rickandmortyapi.com/api/location/{locationId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    JObject locationData = JObject.Parse(responseBody);

                    Console.WriteLine("----------");
                    Console.WriteLine("Location Information:");
                    Console.WriteLine($"Name: {locationData["name"]}");
                    Console.WriteLine($"Type: {locationData["type"]}");
                    Console.WriteLine($"Dimension: {locationData["dimension"]}");
                    Console.WriteLine("----------");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
