using CountriesApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CountriesApi
{
    class Program
    {
        private const string Url = "https://restcountries.com/v3.1/all";

        public static async Task Main(string[] args)
        {
            await GenerateCountryDataFiles();
        }

        public static async Task GenerateCountryDataFiles()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(Url);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(responseBody);

                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string countriesFolderPath = Path.Combine(desktopPath, "Countries");


                        if (!Directory.Exists(countriesFolderPath))
                        {
                            Directory.CreateDirectory(countriesFolderPath);
                        }

                        if (countries != null)
                        {
                            foreach (var country in countries)
                            {
                                string fileName = $"{country.Name.Common}.txt";
                                // Path to the country file
                                string countryFilePath = Path.Combine(countriesFolderPath, fileName);

                                using (StreamWriter writer = new StreamWriter(countryFilePath))
                                {
                                    writer.WriteLine($"Country: {country.Name.Common}");
                                    writer.WriteLine($"Region: {country.Region}");
                                    writer.WriteLine($"Subregion: {country.Subregion}");
                                    writer.WriteLine($"Population: {country.Population}");
                                    writer.WriteLine($"Area: {country.Area}");
                                }
                            }
                            Console.WriteLine("Files have been generated on your desktop in a folder called: Countries :)");
                        }
                        else
                        {
                            Console.WriteLine("Couldn't deserialize the object.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to make the request. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Http error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
