using ShopСlothes.Interface;
using ShopСlothes.Models;
using ShopСlothes.Repository;

namespace ShopСlothes.Moks
{
    public class MokCars : IAllCategory
    {
       
        private readonly ICarsCategory _categoryCars = new MockCategory();//какой категолии принадлежит конкретній обьект 
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car> {//мы же хотим несколько товаров
                    new Car { Name= "Tesla" , ShortDesc ="пушка Ракета",LongDesc="",
                        Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",Price=45000,IsFavourit=true,
                        //куда принадлежить эта категолия
                        Avalible=true,
                        Category=_categoryCars.AllCategory.First()},//берем первую категолию потому что у нас тесла 
 
                    new Car { Name= "BMV" , ShortDesc ="салон мне нрав",LongDesc="BMW - немецкая компания, которая выпускает автомобили и мотоциклы премиум класса. Eе штаб-квартира расположена в городе Мюнхен, а история начинается в 1917 году, когда Карл Рапп и Густав Отто основывают собственный завод по выпуску авиадвигателей Bayerische Motoren Werke – BMW.",
                        Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",Price=8800,IsFavourit=true,
                        Avalible=true,Category=_categoryCars.AllCategory.Last()},


                     new Car { Name= "Ford" , ShortDesc ="мусор полный",LongDesc="В 1920-1930-е годы «Форд Мотор» активно открывает отделения во многих странах мира, в том числе сотрудничает с Советской Россией (создание заводов ГАЗ, АМО). Хотя Генри Форд относился к Октябрьской революции резко отрицательно, тем не менее он считал, что у России большое будущее, если она встанет на путь индустриального развития.",
                         Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",Price=47500,
                         IsFavourit=true,
                        Avalible=true,
                         Category=_categoryCars.AllCategory.First()},

                      new Car { Name= "Volvo" , ShortDesc ="ну хз хз надо подумать",LongDesc="— концерн, производящий коммерческие и грузовые автомобили, автобусы, двигатели и различное оборудование. Ранее концерн Volvo производил также легковые автомобили, но в 1999 продал своё отделение легковых автомобилей под именем Volvo Personvagnar (Volvo Cars) концерну Ford, который в 2010 году перепродал его концерну Geely.",
                          Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",Price=10000,
                          IsFavourit=true,
                        Avalible=true,
                          Category=_categoryCars.AllCategory.Last()},

                       new Car { Name= "Audi" , ShortDesc ="мечта ",LongDesc="жрет очень много но мне нрав ",
                           Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",Price=45000,IsFavourit=true,
                        Avalible=true,
                           Category=_categoryCars.AllCategory.First()},

                        new Car { Name= "Jeep" , ShortDesc ="МегаТрак",LongDesc="по офроуду пойдет а так по городу ну такое",
                            Img="https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                            Price=20000,
                            IsFavourit=false,
                        Avalible=true,
                            Category=_categoryCars.AllCategory.First()}
            };
              
            }

        }
        public IEnumerable<Car> GetFavCar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
       

        public Car GetOjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
