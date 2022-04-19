using AspNetApp.interfaces;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _allCars;
        public HomeController(IAllCars iAllCars)
        {
            _allCars = iAllCars;
        }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _allCars.getFavCars
            };
            return View(homeCars);
        }
    }
}
