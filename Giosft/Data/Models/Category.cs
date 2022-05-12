using System.Collections.Generic;

namespace Site_1.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List<Car> Cars{set; get;}
    }
}
