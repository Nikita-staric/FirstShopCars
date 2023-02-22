using Microsoft.EntityFrameworkCore;
using ShopСlothes.Models;

namespace ShopСlothes
{
    public class AppDataContext : DbContext
    {

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
            Database.EnsureDeleted();   // удаляем бд со старой схемойThe property 'OrderDetail.orderDetali' is of type 'List<OrderDetail>' which is not supported by the current database provider. Either change the property CLR type, or ignore the property using the '[NotMapped]' attribute or by using 'EntityTypeBuilder.Ignore' in 'OnModelCreating'."

            Database.EnsureCreated();   // создаем бд с новой схемой
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    //var multitenantTypes = typeof(OrderDetail)
        //    //   .Assembly
        //    //   .GetTypes()
        //    //   .Where(x => typeof(OrderDetail).IsAssignableFrom(x))
        //    //   .ToArray();

        //    //foreach (var typeToIgnore in multitenantTypes)
        //    //{
        //    //    modelBuilder.Ignore(typeToIgnore);
        //    //}


        //    //modelBuilder.Ignore<Company>();
        //    //modelBuilder.Entity<OrderDetail>().HasKey(u => u.orderDetali);
        //    modelBuilder.Entity<OrderDetail>().HasKey(u => u.orderId);//); 
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\\\MSSQLLocalDB;Initial Catalog=Shop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", builder =>
        //    {
        //        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //    });
        //    base.OnConfiguring(optionsBuilder);
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        //}
        //будут таблицки
        public DbSet<Car> Cars { get; set; }//устанавливает все товары в магазине
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCarItem> shopCarItem { get; set; }
        //регестрируем таблицки 

        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }

}
