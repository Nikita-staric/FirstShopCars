using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Repository
{
    public class OrderRepository : lalOrdes
    {
        public readonly ShopCart shopCart;//вся наша карзина ,все товары который пользователь может купить ;
            public readonly AppDataContext db;//будем вносить изменение и сохранять в базе данных

        public OrderRepository(ShopCart shopCart, AppDataContext db)
        {
            this.shopCart = shopCart;
            this.db = db;
        }
    
        public void CreateOrdel(Order order)
        {
            order.orderTime = DateTime.Now;//когда сделали заказ
            db.Order.Add(order); //нам надо обавить заказ в базу данных
          var item= shopCart.  //все товары которые приобритает пользователь 

        }
    }
.
