using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site_1.Data;
using Site_1.Data.interfaces;
using Site_1.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Site_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly AppDBContent _db;

        public HomeController(IAllCars carRep, AppDBContent db)
        {
            _carRep = carRep;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Empsearch)
        {
            ViewData["Getemployeedetails"] = Empsearch;

            var empquery = from x in _db.Car select x;
            if (!String.IsNullOrEmpty(Empsearch))
            {
                empquery = empquery.Where(x => x.name.Contains(Empsearch) || x.Category.categoryName.Contains(Empsearch));
            }
            var homeCars = new HomeViewModel
            {
                favCars = await empquery.AsNoTracking().ToListAsync()
            };
            return View(homeCars);
        }


        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favCars = _carRep.getFavCars
            };
            return View(homeCars);
        }
        
    }
}
