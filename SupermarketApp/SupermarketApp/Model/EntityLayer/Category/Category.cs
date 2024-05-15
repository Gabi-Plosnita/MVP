namespace SupermarketApp.Model.EntityLayer
{
    public class Category
    {
        public int CategoryId { get; set; }

        public ECategoryType CategoryType { get; set; }

        public virtual List<Product> Products { get; set; }

        public bool? IsActive { get; set; }
    }
}
