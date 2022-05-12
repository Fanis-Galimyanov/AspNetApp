using Microsoft.AspNetCore.Mvc;
using Site_1.Data.interfaces;
using Site_1.Data.Models;
using Site_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Site_1.Controllers
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
       
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            //string _category = category;
            IEnumerable<Car> cars = null;
            string currСategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                    currСategory = "Электромобили";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Класические автомобильи")).OrderBy(i => i.id);
                    currСategory = "Класические автомобильи";
                }
            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currСategory
            };

            ViewBag.title = "Страница об автомобильях";

            return View(carObj);
        }
    }

    
}
