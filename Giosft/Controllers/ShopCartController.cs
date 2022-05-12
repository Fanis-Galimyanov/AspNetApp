using Microsoft.AspNetCore.Mvc;
using Site_1.Data.interfaces;
using Site_1.Data.Models;
using Site_1.ViewModels;
using System.Linq;

namespace Site_1.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllCars _carRep;
        private readonly ShopCart _shopCart;
        
        public ShopCartController(IAllCars carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }

        public ViewResult Index(bool coincidence = false)
        {
            ShopCartViewModel ShopCartItemS = new ShopCartViewModel() 
                                 { ShopCartItemS = _shopCart.getShopItems()};

            ViewBag.coincidence = coincidence;

            return View(ShopCartItemS);
        }

        public RedirectToActionResult addToCart(int id)
        {
          bool coincidence = false;
          
          if (_carRep.Cars.FirstOrDefault(i => i.id == id) != null)
          {
                _shopCart.listShopItems = _shopCart.getShopItems();

                foreach(var el in _shopCart.listShopItems)
                {
                    if (el.car.id == id) 
                    { 
                        coincidence = true;
                        break;
                    }
                }

                if (!coincidence)
                    _shopCart.AddToCart(_carRep.Cars.FirstOrDefault(i => i.id == id));
                                    
          }

            if (coincidence) 
            { 
                return RedirectToAction("Index", new { coincidence = true });
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public RedirectToActionResult deleteToCart(int id)
        {

            _shopCart.DeleteToCart(id);
          
            return RedirectToAction("Index");
        }


    }
}
