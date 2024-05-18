using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.BusinessLogicLayer.Services
{
    public interface ICategoryService
    {
        List<CategoryResponseDto> GetCategories();

        CategoryResponseDto GetCategory(int id);

        void AddCategory(CategoryRequestDto category);

        void UpdateCategory(int id, CategoryRequestDto updatedCategory);

        void DeleteCategory(int id);

        double GetTotalCategoryValue(int id);

        List<ProductResponseDto> GetProductsFromCategory(int id);
    }
}
