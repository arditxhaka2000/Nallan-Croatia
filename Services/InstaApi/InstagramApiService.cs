using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.InstaApi
{
    public class InstagramApiService : IInstagramApiService
    {
        private readonly HttpClient _httpClient;

        // Cache for Instagram data
        private static List<InstagramApi> _cachedData = new();
        private static DateTime _lastFetchTime = DateTime.MinValue;

        public InstagramApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<InstagramApi>> GetInstagramMediaAsync()
        {
            // Check if the data is fresh (within the last 3 hours)
            if (_cachedData.Any() && (DateTime.Now - _lastFetchTime).TotalHours < 3)
            {
                return _cachedData;
            }

            try
            {
                // Fetch fresh data from Instagram API
                var url = "https://graph.instagram.com/me/media?fields=id,media_type,media_url,thumbnail_url&access_token=YOUR_ACCESS_TOKEN";
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true // This ensures casing difference won't matter
                    };

                    var result = JsonSerializer.Deserialize<InstagramMediaResponse>(jsonString, options);

                    // Cache the new data and update the timestamp
                    _cachedData = result?.Data
                        .Where(media => media.media_type == "IMAGE") // Filter by media type
                        .Take(4)
                        .ToList() ?? new List<InstagramApi>();
                    _lastFetchTime = DateTime.Now;

                    return _cachedData;
                }

                throw new HttpRequestException($"Error fetching Instagram media: {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                // Log the exception (use your logging framework)
                Console.WriteLine($"Instagram API fetch failed: {ex.Message}");

                // Return a fallback data indicating a connection problem
                return new List<InstagramApi>
        {
            new InstagramApi
            {
                id = "fallback",
                media_url = "",
                media_type = "TEXT",
            }
        };
            }
        }

    }
}
