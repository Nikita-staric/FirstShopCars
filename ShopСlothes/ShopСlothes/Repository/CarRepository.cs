using System.Data.Entity;
using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Repository
{
    public class CarRepository : IAllCategory
        
    {
        private readonly AppDataContext appDataContext;//можем брать все данные из базы данных через ссылкуб
        public CarRepository(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
           
        }

        public IEnumerable<Car> Cars => appDataContext.Cars.Include(c=>c.Category);//Для загрузки связанных данных используется метод Include:
        public IEnumerable<Car> GetFavCar => appDataContext.Cars.Where(p => p.IsFavourit).Include(c => c.Category);//получаем обект Саrs и будем выберать IsFavourit=true тоесть будт выводить те что у нас в избраных 

        //  IEnumerable<Car> IAllCategory.Cars  => 
        // IEnumerable<Car> IAllCategory.GetFavCar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car GetOjectCar(int carId) => appDataContext.Cars.FirstOrDefault(c => c.Id == carId);//берем первый елемент или один елемент ,берем один елемент который равен carId  
    }
   
}
