using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var item = shopCart.listShopItems;

            foreach (var el in item)
            {
                var orderDetails = new OrderDetail()
                {
                    CarID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appDBContent.orderDetails.Add(orderDetails);
            }
            appDBContent.SaveChanges();
        }
    }
}
