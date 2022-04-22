using AspNetApp.interfaces;
using AspNetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItems = shopCart.getShopCartItems();
            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас должны бьыть товары!");
            }
           /* if(ModelState.IsValid)
            {*/
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            /*}*/
            return View(order);
        }

        public ViewResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
