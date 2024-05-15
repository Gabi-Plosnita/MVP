namespace SupermarketApp.Model.EntityLayer
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public bool? IsActive { get; set; }
    }
}
