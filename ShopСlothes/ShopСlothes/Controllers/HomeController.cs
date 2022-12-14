using Microsoft.AspNetCore.Mvc;
using ShopСlothes.Interface;
using ShopСlothes.Models;
using ShopСlothes.ViewModels;
using System.Diagnostics;

namespace ShopСlothes.Controllers
{
    public class HomeController : Controller
    {//имеем доступ ко всем товарам

        public readonly ICarsCategory _allCategory; 

        public readonly IAllCategory _allCars;
        public HomeController(ICarsCategory carsCategory, IAllCategory allCategory)
        {
            _allCategory = carsCategory;
            _allCars = allCategory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var newArr = new HomeViewMode
            {
                favCar = _allCars.GetFavCar//получить машинки которые ровн труе
            } ;

            //CarsListView carsListView = new CarsListView();
            //carsListView.GetCars = _allCars.Cars;//передаем обьект с товарами 
            //                                     //   carsListView.cuurCategory="AVto";
            return View(newArr);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}