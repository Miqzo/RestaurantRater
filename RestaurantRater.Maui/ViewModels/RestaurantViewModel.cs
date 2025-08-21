using RestaurantRater.Shared.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace RestaurantRater.Maui.ViewModels
{
    public class RestaurantViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; } = new();

        private readonly HttpClient _httpClient = new();

        public async Task LoadRestaurants()
        {
            try
            {
                var list = await _httpClient.GetFromJsonAsync<List<Restaurant>>("api/restaurants");

                if (list == null)
                {
                    return;
                }

                Restaurants.Clear();
                foreach (var r in list)
                    Restaurants.Add(r);
            }
            catch (Exception ex)
            {
                //Handle network or deserialization errors
                Console.WriteLine($"Error loading restaurants: {ex.Message}");
            }
        }
    }
}
