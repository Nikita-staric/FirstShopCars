using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopСlothes.Models
{
    public class OrderDetail
    {
        //опысывает закас

        public int Id { get; set; }//айди для базы данных
                                   //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // [Key]
        public int orderId { get; set; }
        public int carId { get; set; }
        public uint Price { get; set; }
        public virtual Car car { get; set; }//машину которую мы покупаем 
                                            // public string email { get; set; }
       // [ForeignKey("orderId")]
        public virtual Order Order { get; set; }//заказ с которым мы работаем
       //[NotMapped]
      //  public List<OrderDetail> orderDetali { get; set; } //  будет описывать те товары которые мы приобритаем


    }
}
