using SupermarketApp.Model.BusinessLogicLayer.Services;

namespace SupermarketApp.ViewModel
{
    public class CategoryViewModel
    {
        private readonly ICategoryService _categoryService;

        public CategoryViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
    }
}
