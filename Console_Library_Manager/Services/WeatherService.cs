using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Console_Library_Manager.Services
{
    public class WeatherService
    {
        public async static void FetchWeather()
        {
            using HttpClient client = new HttpClient();

            Console.Write("Enter city: ");
            string city = Console.ReadLine()!;

            string geo = await client.GetStringAsync(
             $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(city)}&count=10");

            using var doc = JsonDocument.Parse(geo);

            if (!doc.RootElement.TryGetProperty("results", out var results)
                || results.GetArrayLength() == 0)
            {
                Console.WriteLine("City not found or API returned no results.");
                return;
            }

            var location = results[0];
            double lat = location.GetProperty("latitude").GetDouble();
            double lon = location.GetProperty("longitude").GetDouble();

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m";

            string json = await client.GetStringAsync(url);
            using var weather = JsonDocument.Parse(json);

            var current = weather.RootElement.GetProperty("current");

            Console.WriteLine($"City: {location.GetProperty("name").GetString()}");
            Console.WriteLine($"Temperature: {current.GetProperty("temperature_2m").GetDouble()} °C");
            Console.WriteLine($"Humidity: {current.GetProperty("relative_humidity_2m").GetInt32()}%");

        }
    }
}
