namespace SupermarketApp.Model.EntityLayer.Offers
{
    public class Offer
    {
        public int OfferId { get; set; }

        public EOfferType OfferType { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public double OfferPercentage { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
