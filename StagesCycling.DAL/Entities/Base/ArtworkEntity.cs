namespace StagesCycling.DAL.Entities.Base
{
    public class ArtworkEntity : BaseEntity
    {
        public string Title { get; set; }

        public string CustomImageUrl { get; set; }

        public string CustomColor { get; set; }

        public long BasePriceId { get; set; }

        public virtual BasePrice BasePrice { get; set; }

        public string Sourcing { get; set; }

        public string SKU { get; set; }

        public bool DefaultSC2 { get; set; }

        public bool DefaultSC3 { get; set; }
    }
}
