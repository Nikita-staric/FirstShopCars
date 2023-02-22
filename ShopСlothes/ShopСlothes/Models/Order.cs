using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ShopСlothes.Models
{
    //клас для оформление покупателя(имя фамилия адрес)когда пользователь будет входить в корзину нажимать на оплатить он должен внести свои данные
    public class Order
    {
        [BindNever]//даное поле не будет показано на странице 
        public int Id { get; set; }//айди для базы данных

        [Display(Name="Имя бегом на базу")]
        [StringLength(2)]
        [Required(ErrorMessage ="имя с одной буквы?я понял")]
        public string Name { get; set; }

        [Display(Name = "Фамилию бегом")]
        [StringLength(15)]
        [Required(ErrorMessage = "ты рандом?")]
        public string SurName { get; set; }

        [Display(Name = "суда приедет ФБР")]
        [StringLength(20)]
        [Required(ErrorMessage = "барт,по чесноку")]
        public string adres { get; set; }

        [Display(Name = "номер для кредита нужен")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "не наебешь")]
        public string Phone{ get; set; }

        [Display(Name = "буду тебе спам отправлять ")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "адрес дай норм")]
        public string email { get; set; }

        [BindNever]//даное поле не будет показано на странице 
        [ScaffoldColumn(false)]//что б поле не показывалась при компиляции 
        public DateTime orderTime { get; set; }//во сколько сделал заказ
        public List<OrderDetail> orderDetali { get; set; } //  будет описывать те товары которые мы приобритаем


    }
}
