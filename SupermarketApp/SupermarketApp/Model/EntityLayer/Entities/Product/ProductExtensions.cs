namespace SupermarketApp.Model.EntityLayer
{
    public static class ProductExtensions
    {
        public static void Update(this Product product, Product updatedProduct)
        {
            product.Name = updatedProduct.Name;
            product.Barcode = updatedProduct.Barcode;
            product.CategoryId = updatedProduct.CategoryId;
            product.SupplierId = updatedProduct.SupplierId;
        }
    }
}
