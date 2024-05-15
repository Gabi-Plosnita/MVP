using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext context) : base(context)
        {
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }
            return category;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(int id, Category updatedCategory)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            _context.Entry(category).CurrentValues.SetValues(updatedCategory); // set properties by hand if this line make trouble
            category.CategoryId = id;

            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            category.IsActive = false;
            _context.SaveChanges();
        }

        public double GetTotalCategoryValue(int id)
        {
            var category = _context.Categories.Find(id);
            if(category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            double totalValue = 0;
            var products = category.Products;
            foreach(var product in products)
            {
                var stocks = product.Stocks;
                foreach(var stock in stocks)
                {
                    totalValue += stock.SalePrice * stock.Quantity; 
                }
            }

            return totalValue;
        }

    }
}
