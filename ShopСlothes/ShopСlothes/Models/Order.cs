namespace ShopСlothes.Models
{
    //клас для оформление покупателя(имя фамилия адрес)когда пользователь будет входить в корзину нажимать на оплатить он должен внести свои данные
    public class Order
    {
        public int Id { get; set; }//айди для базы данных
        public string Name { get; set; }
        public string SurName { get; set; }
        public string adres { get; set; }
        public string Phone{ get; set; }
        public string email { get; set; }
        public DateTime orderTime { get; set; }//во сколько сделал заказ
        public List<OrderDetail> orderDetali { get; set; } //  будет описывать те товары которые мы приобритаем


    }
}
