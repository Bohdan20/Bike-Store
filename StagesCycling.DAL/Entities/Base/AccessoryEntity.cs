using System.ComponentModel.DataAnnotations;

namespace StagesCycling.DAL.Entities.Base
{

    public class AccessoryEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Sourcing { get; set; }

        [Required]
        [Display(Name = "Base price")]
        public decimal BasePrice { get; set; }

        [Display(Name = "Item Defined Cost")]
        public decimal? ItemDefinedCost { get; set; }

        public string SKU { get; set; }

        public string ImageUrl { get; set; }
    }
}
