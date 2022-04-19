using AspNetApp.Models;

namespace AspNetApp.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string currCategory { get; set; }
    }
}
