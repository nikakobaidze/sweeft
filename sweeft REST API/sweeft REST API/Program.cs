using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;


namespace sweeft_REST_API
{

    internal class Program
    {
        public void GenerateCountryDataFiles()
        {
            // Make a request to the REST API to get information about all countries
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://restcountries.com/v3.1/all").Result;
                var content = response.Content.ReadAsStringAsync().Result;

                // Parse the response JSON into a JArray
                var countries = JArray.Parse(content);

                // Iterate through each country in the array
                foreach (var country in countries)
                {
                    // Get the country name
                    var name = (string)country["name"]["common"];

                    // Create a text file with the country name
                    var filename = $"{name}.txt";
                    using (var writer = new StreamWriter(filename))
                    {
                        // Write the country information to the file
                        writer.WriteLine($"Country: {name}");
                        writer.WriteLine($"Region: {country["region"]}");
                        writer.WriteLine($"Subregion: {country["subregion"]}");
                        writer.WriteLine($"Latlng: {string.Join(", ", country["latlng"])}");
                        writer.WriteLine($"Area: {country["area"]}");
                        writer.WriteLine($"Population: {country["population"]}");
                    }
                }
            }
        }
        



        static void Main(string[] args)
        {
        }
    }
}
