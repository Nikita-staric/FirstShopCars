using ShopСlothes.Models;

namespace ShopСlothes.Interface
{
    public interface IAllCategory //для работы с товарами ,
    {
        IEnumerable<Car> Cars { get; }//возращает все товары
        IEnumerable<Car> GetFavCar { get;  }//будет возращает избраные товары
        Car GetOjectCar(int carId);//возращает по id
    }
}       
