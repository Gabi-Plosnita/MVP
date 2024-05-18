namespace SupermarketApp.Model.EntityLayer
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public virtual List<Product> Products { get; set; }

        public bool? IsActive { get; set; }

    }
}
