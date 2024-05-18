namespace SupermarketApp.Model.EntityLayer
{
    public class Offer
    {
        public int OfferId { get; set; }

        public EOfferType OfferType { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public double OfferPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
