using AspNetApp.Models;

namespace AspNetApp.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
