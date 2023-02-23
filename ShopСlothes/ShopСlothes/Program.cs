using Microsoft.Extensions.Hosting;
using ShopСlothes.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ShopСlothes;
using ShopСlothes.Interface;
using ShopСlothes.Moks;
using ShopСlothes.Repository;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
// получаем строку подключения из файла конфигурации
//string connection = builder.Configuration.GetConnectionString("NewConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
//builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(connection));

string connection = builder.Configuration.GetConnectionString("NewConnection");

builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));

//builder.Services.AddDbContext(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")); });
builder.Services.AddTransient<IAllCategory, CarRepository>();
builder.Services.AddTransient<lalOrdes, OrderRepository>();
//builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddTransient<ICarsCategory, CategoryRepository>();//связь между ними
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp =>ShopCart.GetCart(sp));//если два пользователя войдут в корзину и что б у них разные корзины были


builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddMvc();
builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) 
{
   
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//void Configuration(IApplicationBuilder aaa)
//{
//    aaa.UseStaticFiles();
//    aaa.UseStatusCodePages();
//    app.UseAuthorization();

    using (var options = ((IApplicationBuilder)app).ApplicationServices.CreateScope())//окружить в область ,создание области
{
        AppDataContext context = options.ServiceProvider.GetRequiredService<AppDataContext>();//какой сервис подключаем
        DbObject.Initial(context);//вызиваем функцию
    }
// void ConfigureServices(IServiceCollection services)
//{
//    app.UseMvc(routes =>
//    {
//        routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
//        // routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{catogory?}", default, new { Controller = "Car", action = "List" });//для электр машин и класика 
//    });

//}
//app.UseMvc(routes =>
//{
//  routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
//    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{catogory?}", default, new { Controller = "Car", action = "List" });//для электр машин и класика 
//});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "Car/{action}/{catogory?}",
//    defaults:new{ Controller = "Car", action = "List" }
//    ); //} "categoryFilter", template: "Car/{action}/{catogory?}", default, new { Controller = "Car", action = "List" });
app.MapControllerRoute(
name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();







//IApplicationBuilder apppp=null;
//var aa= apppp.ApplicationServices.CreateScope()
/*AppDataContext context*/
;
//обращаемся к серв но он т
// ((IApplicationBuilder)app).ApplicationServices.CreateScope())
//ут









//IServiceProvider services=null;
//using IServiceScope serviceScope = services.CreateScope();






// var provider = new ServiceCollection()
//           .AddScoped<AppDataContext>()
//           .BuildServiceProvider();

//using (var scope = provider.CreateScope())
//{
//    var foo = scope.ServiceProvider.GetRequiredService<AppDataContext>();
//} //


//var proveider = new ServiceCollection();

//using (var scope = provider.CreateScope())
//{
//    var foo = scope.ServiceProvider.GetRequiredService<AppDataContext>();
//}



//using (var options = app.ApplicationServices.CreateScope())//окружить в область ,создание области
//{
//    IApplicationBuilder context = (IApplicationBuilder)options.ServiceProvider.GetRequiredService<AppDataContext>();//какой сервис подключаем
//    DbObject.Initial((IApplicationBuilder)context);//вызиваем функцию
//}
//DbObject.Initial(context);//вызиваем функцию


//откометить



//app.MapControllerRoute(
//    name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name:"categoryFilter",pattern: "Car/{action}/{catogory?}");//для электр машин и класика 
