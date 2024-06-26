﻿using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();

        Category GetCategory(int id);

        void AddCategory(Category category);

        void UpdateCategory(int id, Category updatedCategory);

        void DeleteCategory(int id);

        double GetTotalCategoryValue(int id);

        List<Product> GetProductsFromCategory(int id);
    }
}
