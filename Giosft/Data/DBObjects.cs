using Site_1.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Site_1.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
           
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Car.Any())
            {
                content.AttachRange(

                    new Car
                    {
                        name = "Tesla Model S",
                        shortDesc = "Быстрый автомобиль",
                        longDesc = "Tesla Model S — пятидверный электромобиль производства американской компании Tesla. Прототип был впервые показан на Франкфуртском автосалоне в 2009 году; поставки автомобиля в США начались в июне 2012 года",
                        img = "/img/tesla.jpg",
                        price = 11000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "Ford Fiesta",
                        shortDesc = "Тихий и спокойный",
                        longDesc = "Форд Фиеста- это хэтчбек субкомпактного класса. После смены поколения, он насчитывает 4040 мм в длину, 1735 мм в ширину, 1476 мм в высоту и 2493 мм между колесными парами. Дорожный просвет слегка меньше обычного и составляет 140 миллиметров.",
                        img = "/img/fiesta.png",
                        price = 4500,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класические автомобильи"]
                    },
                    new Car
                    {
                        name = "BMV M3",
                        shortDesc = "Дерзкий и стильный",
                        longDesc = "BMW M3 – спортивный роскошный седан всемирно известного немецкого бренда. История модели ведет отсчет с 1986 года. В разное время автомобиль выпускался в кузовах седан, кабриолет, купе и всегда отличался превосходными техническими показателями. На сегодняшний день выпущено пять поколений авто. Машина широко известна во многих странах, включая и Россию.",
                        img = "/img/bmw_m3.jpg",
                        price = 65000,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класические автомобильи"]
                    },
                    new Car
                    {
                        name = "Mercedes C Class",
                        shortDesc = "Уютный и большой",
                        longDesc = "Mercedes-Benz C-класс (ориг. нем. C-Klasse) — серия компактных представительских автомобилей немецкой автомобилестроительной компании Mercedes-Benz, дебютировавшая в 1993 году. Является развитием модели Mercedes-Benz 190[1]. До появления A-класса в 1997 году серия представляла собой наименьшие автомобили как по габаритам, так и по классификации в иерархии марки Mercedes-Benz. ",
                        img = "/img/mercedes_c.jpg",
                        price = 40000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Класические автомобильи"]
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Бесшумный и экологичный",
                        longDesc = "Nissan Leaf построен на новой платформе Nissan V, которую электромобиль делит с кроссовером Juke и малолитражной Micra 2011 модельного года. Под капотом расположен электродвигатель мощностью 80 кВт (около 109 л. с.), чей крутящий момент достигает 280 Н·м. Привод электромобиля — передний.",
                        img = "/img/nissan_ev.jpg",
                        price = 14000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        name = "LADA Ellada",
                        shortDesc = "Российский электромобиль",
                        longDesc = "Первый серийный российский электромобиль производства «АвтоВАЗа»",
                        img = "/img/lada.jpg",
                        price = 10000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Электромобили"]
                    }

                    );
            }

            content.SaveChanges();

        }

        

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                         new Category{categoryName = "Электромобили", desc = "Современный вид транспорта"},
                         new Category {categoryName = "Класические автомобильи", desc = "Машины с двигателем внутреньнего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category;
            }
        }
    }
}

