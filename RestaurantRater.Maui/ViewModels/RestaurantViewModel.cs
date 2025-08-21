using RestaurantRater.Shared.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace RestaurantRater.Maui.ViewModels
{
    public class RestaurantViewModel
    {
        public ObservableCollection<Restaurant> Restaurants { get; set; } = new();

        private readonly HttpClient _httpClient = new();

        public ICommand RefreshCommand { get; }

        public RestaurantViewModel()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5001/") // Set your API base URL here
            };

            // Initialize the command to refresh the restaurant list
            RefreshCommand = new Command(async () => await LoadRestaurants());
        }

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
                // Handle network or deserialization errors
                Console.WriteLine($"Error loading restaurants: {ex.Message}");
            }
        }
    }
}
