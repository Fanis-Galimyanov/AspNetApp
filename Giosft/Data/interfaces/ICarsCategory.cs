

using Site_1.Data.Models;
using System.Collections.Generic;

namespace Site_1.Data.interfaces
{
   public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
