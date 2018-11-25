namespace StagesCycling.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    public class OrderDetail : BaseEntity
    {
        [Key]
        [ForeignKey("Order")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public decimal GrossPrice { get; set; }

        public int Discount { get; set; }

        [Required]
        public decimal NetPrice { get; set; }

        public string Comment { get; set; }

        public string CustomerName { get; set; }

        public bool CreateSalesOrder { get; set; }

        public DateTime DateTimeAdded { get; set; }
    }
}
