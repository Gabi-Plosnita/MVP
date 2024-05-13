namespace SupermarketApp.Model.EntityLayer
{
    public class Category
    {
        public int CategoryId { get; set; }

        public ECategory ECategory { get; set; }

        public bool IsActive { get; set; }
    }
}
