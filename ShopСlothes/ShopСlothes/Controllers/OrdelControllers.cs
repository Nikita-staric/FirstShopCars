using Microsoft.AspNetCore.Mvc;
using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Controllers
{
    public class OrdelControllers:Controller
    {
        public readonly ShopCart shopCart;//вся наша карзина ,все товары который пользователь может купить ;
        public readonly lalOrdes allOrdes;//для заказа

        public OrdelControllers(ShopCart shopCart, lalOrdes allOrdes)
        {
            this.shopCart = shopCart;
            this.allOrdes = allOrdes;
        }
        //форма который пользователь будет вводить свои данные и купить 
        public IActionResult CheckOut()//функуия будет вызвана при заказе
        {
            return View();
        }
        [HttpPost]//у нас метод пост когда будет оплавлять мы будем ловить 
        public IActionResult CheckOut(Order order)//функуия будет вызвана при заказе  Order-получаем имя фамилия номер
        {
            //shopCarItem берем все товары
            shopCart.shopCarItem = shopCart.GetShopItem();//берем все товары с коризины и ложим в список
          
            if(shopCart.shopCarItem.Count==0)//если товара вообще нету
            {
                ModelState.AddModelError(" ", "Бро ,где товара,давай покупай по приказу ");//ключ первый парметр второе сообщение
            }
            //если товары есть товары и все норм
            if(ModelState.IsValid)
            {
                allOrdes.CreateOrdel(order);//создаем заказа 
                return RedirectToAction("Complate");
            }
            //когда мы полностью обновили страницу и там были данные они останутся потому что мы возращаем обьект

            return View(order);
        }
        public IActionResult Complate()
        {
            ViewBag.Message("заказ успешно подтвержден");
            return View();
               
        }
    }
}
