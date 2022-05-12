using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Site_1.Data.interfaces;
using Site_1.Data.Models;

namespace Site_1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allorders;
        private readonly ShopCart shopCart;
        
        private readonly ILogger<OrderController> _logger;
        private readonly Service service;

        public OrderController(IAllOrders allOrders, ShopCart shopCart, Service service)
        {
            this.allorders = allOrders;
            this.shopCart = shopCart;
            this.service = service;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();

            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            if (ModelState.IsValid)
            {
                allorders.createOrder(order);
                service.SendEmail(order);
                return RedirectToAction("Complete");
            }

            return View(order);

        }

        public ViewResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
