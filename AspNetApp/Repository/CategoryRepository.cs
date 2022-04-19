using AspNetApp.interfaces;
using AspNetApp.Models;

namespace AspNetApp.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent _appDbContent;
        public CategoryRepository(AppDBContent appDbContent)
        {
            this._appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => _appDbContent.Category;
    }
}
