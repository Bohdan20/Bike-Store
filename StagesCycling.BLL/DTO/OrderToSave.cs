namespace StagesCycling.BLL.DTO
{
    public class OrderToSave
    {
        #region OrderDetails

        public decimal GrossPrice { get; set; }

        public int Discount { get; set; }

        public decimal NetPrice { get; set; }

        public string Comment { get; set; }

        public string CustomerName { get; set; }

        #endregion

        #region Cycle

        public int CycleQuantity { get; set; }

        public string ModelType { get; set; }

        public long HandlebarTypeId { get; set; }

        public long PlasticsColorTypeId { get; set; }

        public long SprintShiftTypeId { get; set; }

        public long PowerMeterTypeId { get; set; }

        public long? PedalTypeId { get; set; }

        public long? ConsoleTypeId { get; set; }

        public long? SeatTypeId { get; set; }

        public long? ArtworkBeltGuardId { get; set; }
        public string ArtworkBeltGuardColor { get; set; }
        public string ArtworkBeltGuardImageUrl { get; set; }

        public long? ArtworkFlywheelId { get; set; }
        public string ArtworkFlywheelColor { get; set; }
        public string ArtworkFlywheelImageUrl { get; set; }

        public long? ArtworkFrameForkId { get; set; }
        public string ArtworkFrameForkColor { get; set; }
        public string ArtworkFrameForkImageUrl { get; set; }

        public long? PaintColorId { get; set; }
        public string CustomColor { get; set; }
        #endregion

        #region Accessories

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

        #endregion
    }
}
