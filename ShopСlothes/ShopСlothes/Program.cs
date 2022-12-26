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
string connection = builder.Configuration.GetConnectionString("NewConnection");
// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));
builder.Services.AddTransient<IAllCategory, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();//связь между ними
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp =>ShopCart.GetCart(sp));//если два пользователя войдут в корзину и что б у них разные корзины были


builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddMvc();
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
////DbObject.Initial(app);//вызиваем функцию
AppDataContext context;
//обращаемся к сервысу но он тут
using (var options = ((IApplicationBuilder)app).ApplicationServices.CreateScope())//окружить в область ,создание области
{
    context = options.ServiceProvider.GetRequiredService<AppDataContext>();//какой сервис подключаем
    DbObject.Initial(context);//вызиваем функцию
}
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{catogory?}", default,new {Controller="Car",action="List"});//для электр машин и класика 
});
//app.MapControllerRoute(
//    name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name:"categoryFilter",pattern: "Car/{action}/{catogory?}");//для электр машин и класика 

app.Run();
