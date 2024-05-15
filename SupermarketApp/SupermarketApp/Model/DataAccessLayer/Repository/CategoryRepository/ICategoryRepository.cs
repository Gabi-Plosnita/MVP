using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        Category GetCategory(int id);

        void AddCategory(Category category);

        void UpdateCategory(int id, Category updatedCategory);

        void DeleteCategory(int id);
    }
}
