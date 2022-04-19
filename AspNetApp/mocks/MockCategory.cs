using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{categoryName = "Электромобили", desc = "Современный вид транспорта"},
                    new Category {categoryName = "Класические автомобильи", desc = "Машины с двигателем внутреньнего сгорания"}
                };
            }
        }
    }
}
