using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopСlothes.Interface;
using ShopСlothes.Models;
using ShopСlothes.ViewModels;

namespace ShopСlothes.Controllers
{
    public class CarsController : Controller
    {
        public readonly ICarsCategory _allCategory;

        public readonly IAllCategory _allCars;
        public CarsController(ICarsCategory carsCategory, IAllCategory allCategory)
        {
            _allCategory = carsCategory;
            _allCars = allCategory;
        }
        [Route("Cars/List")]//при переходи по этому URL адресу функция будет срабатывать
        [Route("Cars/List/category")]
        public IActionResult Index(string category)//передаем категорию Электро
        {
            string _categoy = category;//хранит
            IEnumerable<Car> cars = null;//помещать все машины 
            string carrCategory = "";
            if(string.IsNullOrEmpty(category))//если 3-ий параметр пустой то прийдется все машины вывести   IsNullOrEmpty-пуста или не существует
            {
                cars = _allCars.Cars.OrderBy(i=>i.Id);  //если строка пустая выводим все машины
            }
            else//если параметр не пустой
            {
                //string.Equals если строка ровна слову  electro 2(парметр) какая страка 3(неучитываем регимтр Верхняя буква)
                if (string.Equals("electro", category,StringComparison.OrdinalIgnoreCase))//надо понять что находится в category
                {


                    //Categoryy может тут ошибка категориНаме передать 
                 cars = _allCars.Cars.Where(i => i.Category.Categoryy.Equals("ЭлектроМобиль")).OrderBy(i => i.Id);
                    carrCategory = "ЭлектроМобиль";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.Categoryy.Equals("Класические машинны")).OrderBy(i => i.Id);// БУДУТ ПРИНАДЛЕЖАТЬ К ЭЛЕКТРОМОБИЛЯМ 
                    carrCategory = "Класические машинны";
                }
            }
            //OrderBy сортировка
            carrCategory = _categoy;//с какой категории работаем
            var carObject = new CarsListView
            {
                GetCars = cars,
                CuurCategory=carrCategory,
            };

            ViewBag.Title = "Страница с автомобилями";
            //CarsListView obj = new CarsListView();
            //obj.GetCars = _allCars.Cars;//передаем обьект с товарами 
            //obj.cuurCategory = "Авто";                               //   carsListView.cuurCategory="AVto";
            return View(carObject);
        }


        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
