using ShopСlothes.Models;

namespace ShopСlothes.ViewModels
{
   public class CarsListView
    {
        public IEnumerable<Car> GetCars { get; set; }
        public string cuurCategory { get; set; }
    }
}
 