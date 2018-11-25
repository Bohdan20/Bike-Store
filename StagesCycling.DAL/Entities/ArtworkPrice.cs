namespace StagesCycling.DAL.Entities
{
    using Base;

    public class ArtworkPrice : BaseEntity
    {
        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}
