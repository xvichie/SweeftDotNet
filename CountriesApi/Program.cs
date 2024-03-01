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
        private static readonly string Url = "https://restcountries.com/v3.1/all";

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
                        Console.WriteLine(responseBody);
                        List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(responseBody);

                        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        // Path to countries folder
                        string countriesFolderPath = Path.Combine(desktopPath, "countries");

                        // Check if countries folder exists, if not, create it
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
                        }
                        else
                        {
                            Console.WriteLine("Failed to deserialize the response.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to make request. Status code: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HTTP request error: {ex.Message}");
                }
                //catch (JsonException ex)
                //{
                //    Console.WriteLine($"JSON parsing error: {ex.Message}");
                //}
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
