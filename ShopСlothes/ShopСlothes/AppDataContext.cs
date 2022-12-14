using Microsoft.EntityFrameworkCore;
using ShopСlothes.Models;

namespace ShopСlothes
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
         //   Database.EnsureCreated();

        }
        //будут таблицки
        public DbSet<Car> Cars { get; set; }//устанавливает все товары в магазине
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCarItem> shopCarItem { get; set; }

    }

}
