﻿using Microsoft.EntityFrameworkCore;
using SupermarketApp.Model.DataAccessLayer.DataContext;
using SupermarketApp.Model.EntityLayer;

namespace SupermarketApp.Model.DataAccessLayer.Repository
{
    public class SupplierRepository : BaseRepository, ISupplierRepository
    {
        public SupplierRepository()
        {
        }

        public List<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            return supplier;
        }

        public void AddSupplier(Supplier supplier)
        {
            if(_context.Suppliers.Any(s => (s.Name == supplier.Name && s.Country == supplier.Country)))
            {
                throw new Exception($"Supplier with name {supplier.Name} and country {supplier.Country} already exists");
            }

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(int id, Supplier updatedSupplier)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }
            if(_context.Suppliers.Any(s => (s.Name == updatedSupplier.Name && s.Country == updatedSupplier.Country
                                            && s.Name != supplier.Name && s.Country != supplier.Country)))
            {
                throw new Exception($"Supplier with name {updatedSupplier.Name} and country {updatedSupplier.Country} already exists");
            }

            supplier.Update(updatedSupplier);
            _context.SaveChanges();
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers
                                   .Include(s => s.Products)
                                   .FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            if(supplier.Products.Count > 0)
            {
                throw new Exception($"Supplier with id {id} has products and can't be deleted");
            }

            supplier.IsActive = false;
            _context.SaveChanges();
        }  

        public List<Product> GetProductsFromSupplier(int id)
        {
            var supplier = _context.Suppliers
                                   .Include(s => s.Products)
                                   .ThenInclude(p => p.Category)
                                   .Include(s => s.Products)
                                   .ThenInclude(p => p.Supplier)
                                   .FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with id {id} not found");
            }

            return supplier.Products.ToList();
        }
    }
}
