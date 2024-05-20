namespace SupermarketApp.Model.EntityLayer.Entities
{
    public static class CategoryExtensions
    {
        public static void Update(this Category category, Category updatedCategory)
        {
            category.Name = updatedCategory.Name;
        }
    }
}
