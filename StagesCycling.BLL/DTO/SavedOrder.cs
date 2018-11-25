namespace StagesCycling.BLL.DTO
{
    using System.Collections.Generic;

    public class SavedOrder
    {
        public SavedOrder()
        {
            SavedItems = new List<SavedItem>();
        }

        public IEnumerable<SavedItem> SavedItems { get; set; }

        public int Discount { get; set; }
        public decimal NetPrice { get; set; }

        public int CycleQuantity { get; set; }

        public int AerobarQuantity { get; set; }
        public int HandlebarPostQuantity { get; set; }
        public int MediaShelfQuantity { get; set; }
        public int PhoneHolderQuantity { get; set; }
        public int SeatPostQuantity { get; set; }
        public int StagesDumbbellHolderQuantity { get; set; }
        public int TabletHolderQuantity { get; set; }

    }
}
