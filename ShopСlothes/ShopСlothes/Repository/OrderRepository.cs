using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Repository
{
    public class OrderRepository : lalOrdes
    {
        public readonly ShopCart shopCart;//вся наша карзина ,все товары который пользователь может купить ;
        public readonly AppDataContext db;//будем вносить изменение и сохранять в базе данных
        //public List<OrderDetail> shopCarItemmm { get; set; }
        public OrderRepository(ShopCart shopCart, AppDataContext db)
        {
            this.shopCart = shopCart;
            this.db = db;
        }

        public void CreateOrdel(Order order)//создаем заказ 
        {
            order.orderTime = DateTime.Now;//когда сделали заказ
            db.Order.Add(order); //нам надо добавить заказ в базу данных
            var item = shopCart.shopCarItem;  //все товары которые приобритает пользователь 
                                              //опишим класс OrderDetali
            foreach (var elemen in item)
            {
                var orderDetali = new OrderDetail()
                {
                    carId = elemen.car.Id,
                    orderId = order.Id,
                    Price = elemen.car.Price

                };

                //после каждго заказа добавляем в базу данных
                db.OrderDetail.Add(orderDetali);
            }
            db.SaveChanges();
        }
    }
}

