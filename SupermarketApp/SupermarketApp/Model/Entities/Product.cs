namespace SupermarketApp.Model.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Barcode { get; set; }

        public Category Category { get; set; }

        public Supplier Supplier { get; set; }
    }
}
