﻿using Microsoft.EntityFrameworkCore;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository()
        {
        }

        public List<Product> GetAllProducts()
        {
            var products = _context.Products
                                   .Include(p => p.Category)
                                   .Include(p => p.Supplier)
                                   .ToList();
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products
                                  .Include(p => p.Category)
                                  .Include(p => p.Supplier)
                                  .FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }

            return product;
        }

        public Product GetProductByName(string name)
        {
            var product = _context.Products
                                  .Include(p => p.Category)
                                  .Include(p => p.Supplier)
                                  .FirstOrDefault(p => p.Name == name);
            if(product == null)
            {
                throw new Exception($"Product with name {name} not found");
            }

            return product;
        }

        public Product GetProductByBarcode(string barcode)
        {
            var product = _context.Products
                                  .Include(p => p.Category)
                                  .Include(p => p.Supplier)
                                  .FirstOrDefault(p => p.Barcode == barcode);
            if(product == null)
            {
                throw new Exception($"Product with barcode {barcode} not found");
            }

            return product;
        }

        public void AddProduct(Product product)
        {
            var category = _context.Categories.Find(product.CategoryId);
            if(category == null)
            {
                throw new Exception($"Category with id {product.CategoryId} not found");
            }

            var supplier = _context.Suppliers.Find(product.SupplierId);
            if(supplier == null)
            {
                throw new Exception($"Supplier with id {product.SupplierId} not found");
            }

            if (_context.Products.Any(p => p.Name == product.Name))
            {
                throw new Exception($"Product with name {product.Name} already exists");
            }

            if (_context.Products.Any(p => p.Barcode == product.Barcode))
            {
                throw new Exception($"Product with barcode {product.Barcode} already exists");
            }

            _context.Products.Add(product);
            _context.SaveChanges();
        }   

        public void UpdateProduct(int id, Product updatedProduct)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }

            var category = _context.Categories.Find(updatedProduct.CategoryId);
            if(category == null)
            {
                throw new Exception($"Category with id {updatedProduct.CategoryId} not found");
            }

            var supplier = _context.Suppliers.Find(updatedProduct.SupplierId);
            if(supplier == null)
            {
                throw new Exception($"Supplier with id {updatedProduct.SupplierId} not found");
            }

            if (_context.Products.Any(p => p.Name == updatedProduct.Name && p.Name != product.Name))
            {
                throw new Exception($"Product with name {updatedProduct.Name} already exists");
            }

            if (_context.Products.Any(p => p.Barcode == updatedProduct.Barcode && p.Barcode != product.Barcode))
            {
                throw new Exception($"Product with barcode {updatedProduct.Barcode} already exists");
            }

            product.Update(updatedProduct);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products
                                  .Include(p => p.Stocks)
                                  .FirstOrDefault(p => p.ProductId == id);
            if(product == null)
            {
                throw new Exception($"Product with id {id} not found");
            }

            if(product.Stocks.Count > 0)
            {
                throw new Exception($"Product with id {id} has stocks and can't be deleted");
            }

            product.IsActive = false;
            _context.SaveChanges();
        }

    }
}
