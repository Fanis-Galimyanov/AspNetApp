using Site_1.Data.interfaces;
using Site_1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site_1.Data.mocks
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
