using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ShopСlothes.Models
{
    //будет опысывать всю карзину 
    //если у нас 4 молока то будет одна карзина ,если 3 молока и 1 хлеб то две карзины 
    public class ShopCart
    {
        public string ShopCartId { get; set; }//айди карзины
        public List<ShopCarItem> shopCarItem { get; set; }
         private readonly AppDataContext appDataContext;//можем брать все данные из базы данных через ссылкуб
        public ShopCart(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;

        }
        public static ShopCart GetCart(IServiceProvider service)//если добавлял раньше товар то добовляем товар,если нет то создаем карзину
        {
            ISession session= service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session ;//создали обект с которой будем работать с сесиями
            var contex = service.GetService<AppDataContext>();//получаем таблицы и работаем с базой 
            var shopcarId = session.GetString("CarId") ?? Guid.NewGuid().ToString();//устанавливаем значение ихз сессии если нету то создаем новый индефикатор
            session.SetString("CarId", shopcarId);//устанавлиеваем новую сесию
            return new ShopCart(contex)//есть ли ссесия с какой карзиной работаем 
            {
                ShopCartId = shopcarId
            };
        
        }
        //продукты будет добовлять в карзину
        public void AddToCar(Car car)//car-
        {
            appDataContext.shopCarItem.Add(new ShopCarItem
            {
                ShopCartId=ShopCartId,
                car=car,
                Price=car.Price
            });
            appDataContext.SaveChanges();
        }
        //будет показывать товары
        public List<ShopCarItem> GetShopItem()
        {
            //Where-выбрать елементы ShopCartId будет равен ShopCartId (айди карзины равен айди в сесии)
            //Include-получить все данные -car получаем все обекты машинки
            //ToList-возращаем List
            return appDataContext.shopCarItem.Where(c => c.ShopCartId == ShopCartId).Include(c => c.car).ToList();
        }
    }
}
