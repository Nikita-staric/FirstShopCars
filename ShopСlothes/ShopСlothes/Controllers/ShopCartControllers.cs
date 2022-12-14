using Microsoft.AspNetCore.Mvc;
using ShopСlothes.Interface;
using ShopСlothes.Models;
using ShopСlothes.Repository;
using ShopСlothes.ViewModels;

namespace ShopСlothes.Controllers
{
    public class ShopCartControllers:Controller //связывать будет модели и шаблоны
    {
        public readonly IAllCategory _carRep;
        public readonly ShopCart _shopCart;
        public ShopCartControllers(IAllCategory carRep, ShopCart shopCart)
        {
            _carRep = carRep;
            _shopCart = shopCart;
        }   
        //вызвать HTML и вывести
       public ViewResult Index()
        {
            var item = _shopCart.GetShopItem();//получим все товары
            _shopCart.shopCarItem = item;//устанавливаем все товары которые есть в корзине
            var obj = new ShopCartViewModel//возращает шаблон
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
       // добавляет товары и будет переадресация на домашнию страницу

        public RedirectToActionResult addToCarss(int id)//id товара
        {
            var gg = _carRep.Cars.FirstOrDefault(a => a.Id == id);//если захотим выбрать товар под айди 15 то будет выбирать под айди 15 и добавляем
            //будет выбирать товар с помощью айди (FirstOrDefault первый элемент или найденый элемент)
            if(gg!=null)
            {
                _shopCart.AddToCar(gg);
            }
            return RedirectToAction("Index");//если мы нажмем добавить товар то мы перекинем пользователя на карзину
        }
    }
}
