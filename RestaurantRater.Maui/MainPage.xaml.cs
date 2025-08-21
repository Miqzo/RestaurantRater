using RestaurantRater.Maui.ViewModels;

namespace RestaurantRater.Maui
{
    public partial class MainPage : ContentPage
    {
        private RestaurantViewModel _viewModel;
        
        public MainPage()
        {
            InitializeComponent();

            _viewModel = new RestaurantViewModel();
            BindingContext = _viewModel;

            // Load the list initially
            Loaded += MainPage_Loaded;
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            await _viewModel.LoadRestaurants();
        }
    }

}
