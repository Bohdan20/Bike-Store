namespace StagesCycling.BLL.DTO
{
    using StagesCycling.DAL.Entities.Accessories;
    using System.Collections.Generic;

    public class AccessoryList
    {
        public IEnumerable<StagesBikeNumberPlate> StagesBikeNumberPlates { get; set; }
        public IEnumerable<Aerobar> Aerobars { get; set; }
        public IEnumerable<HandlebarPost> HandlebarPosts { get; set; }
        public IEnumerable<MediaShelf> MediaShelves { get; set; }
        public IEnumerable<PhoneHolder> PhoneHolders { get; set; }
        public IEnumerable<SeatPost> SeatPosts { get; set; }
        public IEnumerable<StagesDumbbellHolder> StagesDumbbellHolders { get; set; }
        public IEnumerable<TabletHolder> TabletHolders { get; set; }
    }
}
