namespace StagesCycling.DAL.Entities
{
    using Base;

    public class Order: BaseEntity
    {       
        public long? TabletHolderId { get; set; }
        public int TabletHolderQuantity { get; set; }

        public long? PhoneHolderId { get; set; }
        public int PhoneHolderQuantity { get; set; }

        public long? MediaShelfId { get; set; }
        public int MediaShelfQuantity { get; set; }

        public long? SeatPostId { get; set; }
        public int SeatPostQuantity { get; set; }

        public long? HandlebarPostId { get; set; }
        public int HandlebarPostQuantity { get; set; }

        public long? StagesDumbbellHolderId { get; set; }
        public int StagesDumbbellHolderQuantity { get; set; }

        public int AerobarQuantity { get; set; }
        public long? AerobarId { get; set; }

        public int PlatesOneToSixtyQuntity { get; set; }
        public long? PlatesOneToSixtyId { get; set; }

        public long? PlatesSixtyOneToHundredId { get; set; }
        public int PlatesSixtyOneToHundredQuantity { get; set; }

        public long? PlatesOneToEightyId { get; set; }
        public int PlatesOneToEightyQuantity { get; set; }

        public long? PlatesFiftyPeacesId { get; set; }
        public int PlatesFiftyPeacesQuantity { get; set; }

        public long? PlatesOneToThirtyId { get; set; }
        public int PlatesOneToThirtyQuantity { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        public int CycleQuantity { get; set; }
        public virtual Cycle Cycle { get; set; }
    }
}
