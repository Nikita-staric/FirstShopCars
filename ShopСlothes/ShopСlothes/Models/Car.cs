namespace ShopСlothes.Models
{
    public class Car
    {
        public int Id { get; set; }//айди нашего товара
        public string? Name { get; set; }//имя товара
        public string? ShortDesc { get; set; }//описание
        public string? LongDesc { get; set; }//длиное описание 
        public string? Img { get; set; }//фотография по ссылке
        public ushort Price{ get; set; }//цена 
        public bool IsFavourit { get; set; }//на главнй страничке будет
        public bool Avalible { get; set; }//сколько товара осталось
        public int CategoryId { get; set; }//
        public virtual Category? Category { get; set; }//
    }
}
