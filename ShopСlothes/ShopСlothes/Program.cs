using Microsoft.Extensions.Hosting;
using Shop�lothes.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Shop�lothes;
using Shop�lothes.Interface;
using Shop�lothes.Moks;
using Shop�lothes.Repository;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("NewConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NewConnection")));
builder.Services.AddTransient<IAllCategory, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();//����� ����� ����
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp =>ShopCart.GetCart(sp));//���� ��� ������������ ������ � ������� � ��� � � ��� ������ ������� ����


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
////DbObject.Initial(app);//�������� �������
AppDataContext context;
//���������� � ������� �� �� ���
using (var options = ((IApplicationBuilder)app).ApplicationServices.CreateScope())//�������� � ������� ,�������� �������
{
    context = options.ServiceProvider.GetRequiredService<AppDataContext>();//����� ������ ����������
    DbObject.Initial(context);//�������� �������
}
app.UseAuthorization();

app.UseMvc(routes =>
{
    routes.MapRoute(name: "default",template: "{controller=Home}/{action=Index}/{id?}");
    routes.MapRoute(name: "categoryFilter", template: "Car/{action}/{catogory?}", default,new {Controller="Car",action="List"});//��� ������ ����� � ������� 
});
//app.MapControllerRoute(
//    name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name:"categoryFilter",pattern: "Car/{action}/{catogory?}");//��� ������ ����� � ������� 

app.Run();
