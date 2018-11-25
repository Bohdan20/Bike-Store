namespace StagesCycling.DAL.Entities
{
    using Base;

    public class BasePrice : BaseEntity
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}
