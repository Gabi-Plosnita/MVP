using Microsoft.EntityFrameworkCore;
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
            if(_context.Categories.Any(c => c.Name == category.Name))
            {
                throw new Exception($"Category with name {category.Name} already exists");
            }

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

            if(category.Products.Count > 0)
            {
                throw new Exception($"Category with id {id} has products and can't be deleted");
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

        public List<Product> GetProductsFromCategory(int id)
        {
            var category = _context.Categories
                           .Include(c => c.Products)
                           .FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            return category.Products.ToList();
        }

    }
}
