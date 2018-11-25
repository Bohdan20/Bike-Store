namespace StagesCycling.DAL.Entities
{
    using Base;

    public class OrderConfiguration : BaseEntity
    {
        public int MinBikeQuantity { get; set; }
        public decimal MaxDiscount { get; set; }
    }
}
