
namespace ShopСlothes.Models
{
    //отвечать за все товары в карзине
    public class ShopCarItem
    {
        public int Id { get; set; }//айди обекта(машинке какой то 
        public Car car { get; set; }//конкретный обьект 
        public int Price { get; set; }       //цена        
        public string ShopCartId { get; set; }        // айди товара внутри корзине 

    }
}
