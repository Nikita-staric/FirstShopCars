using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using ShopСlothes.Models;

namespace ShopСlothes
{
    public class DbObject//будем обращаться
    {
      

        //возращает список

        public static void Initial(AppDataContext context)//ДОБАВЛЯЕТ ОБЬЕКТЫ И БУДЕМ ВИТЯГИВАТЬ
        {
            //мы тут присвоим но тут пусто

            //AppDataContext context;
            ////обращаемся к сервысу но он тут
            //using (var score = app.ApplicationServices.CreateScope())//окружить в область ,создание области
            //{
            //    context = score.ServiceProvider.GetRequiredService<AppDataContext>();//какой сервис подключаем
            //}





            //    AppDataContext context = app.ApplicationServices.GetRequiredService<AppDataContext>();  //подключени и работа с базой данныx 
            //добавление категорий если нету нечего
            if (!context.Categories.Any())//если их нету
            {
                context.Categories.AddRange(Categoriess.Select(c => c.Value));//Categoriess брать значение и записывать
            }
            // добавляем обекты товара
            if (!context.Categories.Any())//если их нету
            {
                context.AddRange(
                     new Car
                     {
                         Name = "Tesla",
                         ShortDesc = "пушка Ракета",
                         LongDesc = "",
                         Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                         Price = 45000,
                         IsFavourit = true,
                         //куда принадлежить эта категолия
                         Avalible = true,
                         Category = Categoriess["ЭлектроМобиль"]//обращаемся по ключу 
                     },//берем первую категолию потому что у нас тесла 

                    new Car
                    {
                        Name = "BMV",
                        ShortDesc = "салон мне нрав",
                        LongDesc = "BMW - немецкая компания, которая выпускает автомобили и мотоциклы премиум класса. Eе штаб-квартира расположена в городе Мюнхен, а история начинается в 1917 году, когда Карл Рапп и Густав Отто основывают собственный завод по выпуску авиадвигателей Bayerische Motoren Werke – BMW.",
                        Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                        Price = 8800,
                        IsFavourit = true,
                        Avalible = true,
                        Category = Categoriess["Класические машинны"]
                    },


                     new Car
                     {
                         Name = "Ford",
                         ShortDesc = "мусор полный",
                         LongDesc = "В 1920-1930-е годы «Форд Мотор» активно открывает отделения во многих странах мира, в том числе сотрудничает с Советской Россией (создание заводов ГАЗ, АМО). Хотя Генри Форд относился к Октябрьской революции резко отрицательно, тем не менее он считал, что у России большое будущее, если она встанет на путь индустриального развития.",
                         Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                         Price = 47500,
                         IsFavourit = true,
                         Avalible = true,
                         Category = Categoriess["Класические машинны"]
                     },

                      new Car
                      {
                          Name = "Volvo",
                          ShortDesc = "ну хз хз надо подумать",
                          LongDesc = "— концерн, производящий коммерческие и грузовые автомобили, автобусы, двигатели и различное оборудование. Ранее концерн Volvo производил также легковые автомобили, но в 1999 продал своё отделение легковых автомобилей под именем Volvo Personvagnar (Volvo Cars) концерну Ford, который в 2010 году перепродал его концерну Geely.",
                          Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                          Price = 10000,
                          IsFavourit = true,
                          Avalible = true,
                          Category = Categoriess["Класические машинны"]
                      },

                       new Car
                       {
                           Name = "Audi",
                           ShortDesc = "мечта ",
                           LongDesc = "жрет очень много но мне нрав ",
                           Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                           Price = 45000,
                           IsFavourit = true,
                           Avalible = true,
                           Category = Categoriess["ЭлектроМобиль"]
                       },

                        new Car
                        {
                            Name = "Jeep",
                            ShortDesc = "МегаТрак",
                            LongDesc = "по офроуду пойдет а так по городу ну такое",
                            Img = "https://www.zr.ru/_ah/img/1E0AP_kAZdE8Nu045JMruQ=h625",
                            Price = 20000,
                            IsFavourit = false,
                            Avalible = true,
                            Category = Categoriess["Класические машинны"]
                        });
                context.SaveChanges();
            }
        }
        public static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categoriess
        {//возвращать данные ,словарь,передаем ключ стринг,2-тип данных для елементов
            get
            {
                if (category == null)//если пуста то добовляем новый обьект
                {
                    // если пуста
                    var list = new Category[]//список 
                    { //какие категоии будут возращаться 
                    new Category { Categoryy = "ЭлектроМобиль" , Description ="пушка Ракета"},
                    new Category { Categoryy = "Класические машинны" ,Description="Хуита"}

                    };
                    //ВЫДЕЛЯЕМ ПАМИТЬ И ВНУТРЬ ДОБАВЛЯЕМ ВСЕ ЭЛЕМЕНТЫ
                    category = new Dictionary<string, Category>();
                    foreach (Category item in list)
                    {
                        category.Add(item.Categoryy, item);//добавляем новый  элемент
                    }
                }
                //если есть элементы то возращаем
                return category;

            }
        }

    }
}

