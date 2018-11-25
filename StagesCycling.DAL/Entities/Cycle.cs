namespace StagesCycling.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;

    public class Cycle : BaseEntity
    {
        [Key]
        [ForeignKey("Order")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long  Id { get; set; }

        public virtual Order Order { get; set; }

        #region "DetailsWithoutColor"

        public long ModelId { get; set; }

        public long HandlebarTypeId { get; set; }

        public long PlasticsColorTypeId { get; set; }

        public long SprintShiftTypeId { get; set; }

        public long PowerMeterTypeId { get; set; }

        public long? PedalTypeId { get; set; }

        public long? ConsoleTypeId { get; set; }

        public long? SeatTypeId { get; set; }

        #endregion

        public long ArtworkBeltGuardId { get; set; }

        public long? ArtworkFlywheelId { get; set; }

        public long ArtworkFrameForkId { get; set; }

        public long? PaintColorId { get; set; }

        public string CustomColor { get; set; }
    }
}
