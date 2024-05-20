namespace SupermarketApp.Model.EntityLayer
{
    public static class SupplierExtensions
    {
        public static void Update(this Supplier supplier, Supplier updatedSupplier)
        {
            supplier.Name = updatedSupplier.Name;
            supplier.Country = updatedSupplier.Country;
        }
    }
}
