using Microsoft.EntityFrameworkCore;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;
using SupermarketApp.Model.EntityLayer.Entities;

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

            category.Update(updatedCategory);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories
                                   .Include(c => c.Products)
                                   .FirstOrDefault(c => c.CategoryId == id);
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
            var category = _context.Categories
                                   .Include(c => c.Products)
                                   .ThenInclude(p => p.Stocks)
                                   .FirstOrDefault(c => c.CategoryId == id);
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
                           .ThenInclude(p => p.Category)
                           .Include(c => c.Products)
                           .ThenInclude(p => p.Supplier)
                           .FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                throw new Exception($"Category with id {id} not found");
            }

            return category.Products.ToList();
        }

    }
}
