namespace StagesCycling.DAL.Entities
{
    using Base;

    public class PaintColor : BaseEntity
    {
        public string Title { get; set; }

        public string ColorImageUrl { get; set; }

        public string BikeImageUrl { get; set; }

        public long BasePriceId { get; set; }

        public virtual BasePrice BasePrice { get; set; }

        public string Sourcing { get; set; }

        public string SKU { get; set; }

        public bool DefaultSC2 { get; set; }

        public bool DefaultSC3 { get; set; }
    }
}
