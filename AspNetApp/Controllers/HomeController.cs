using AspNetApp.interfaces;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;


        public HomeController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;

        }

        public ViewResult Index()
        {
            ViewBag.Title = "Страница с автомобилями";
            HomeViewModel obj = new HomeViewModel();
            obj.allCars = _allCars.Cars;
            obj.currCategory = "Автомобили";
            return View(obj);
        }
    }
}
