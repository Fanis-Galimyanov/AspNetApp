using AspNetApp.interfaces;
using AspNetApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly AppDBContent _db;
        public HomeController(IAllCars iAllCars, AppDBContent db)
        {
            _allCars = iAllCars;
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string Empsearch)
        {
            ViewData["Getemployeedetails"] = Empsearch;
            var empquery = from x in _db.Car select x;
            if(!String.IsNullOrEmpty(Empsearch))
            {
                empquery =  empquery.Where(x=>x.name.Contains(Empsearch) || x.Category.categoryName.Contains(Empsearch));
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
                favCars = _allCars.getFavCars
            };
            return View(homeCars);
        }
    }
}
