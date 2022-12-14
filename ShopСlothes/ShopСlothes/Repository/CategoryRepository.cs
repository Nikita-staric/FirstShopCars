using ShopСlothes.Interface;
using ShopСlothes.Models;

namespace ShopСlothes.Repository
{
    //
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDataContext appDataContext;//можем брать все данные из базы данных через ссылкуб
        public CategoryRepository(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;

        }

        public IEnumerable<Category> AllCategory => appDataContext.Categories;//получаем все категолии
    }
}
