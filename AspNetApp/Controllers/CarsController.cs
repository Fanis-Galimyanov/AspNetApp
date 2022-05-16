using AspNetApp.interfaces;
using AspNetApp.Models;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;


        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;

        }
        /*[Route("{url}")]*/
        /*[Route("Car")]
        [Route("Car/{url}")]*/
        [Route("Cars/List")]
        [Route("Cars/List/{url}")]
        public ViewResult List(string url)
        {
            IEnumerable<Car> cars = null;
            string currCategory = "Автомобили";

            if(string.IsNullOrEmpty(url))
            {
                cars = _allCars.Cars.OrderBy(car => car.price);
            }
            if(string.Equals("electro",url,StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(car => car.Category.categoryName.Equals("Электромобили")).OrderBy(car => car.price);
                currCategory = "Электромобили";
            }
            if(string.Equals("fuel",url, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(car => car.Category.categoryName.Equals("Класические автомобильи")).OrderBy(car => car.price);
                currCategory = "Класические автомобильи";
            }

            CarsListViewModel carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory
            };
            
            ViewBag.Title = "Страница с автомобилями";

            return View(carObj);
        }
    }
}
