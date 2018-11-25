namespace StagesCycling.BLL.DTO
{
    using DAL.Entities;
    using DAL.Entities.Accessories;
    using System.Collections.Generic;

    public class AdminViewModel
    {
        public IEnumerable<Model> Models { get; set; }

        public IEnumerable<PaintColor> PaintColors { get; set; }
        public IEnumerable<PlasticsColorType> PlasticsColors { get; set; }
        public IEnumerable<SeatType> Seats { get; set; }
        public IEnumerable<HandlebarType> Handlebars { get; set; }
        public IEnumerable<PedalType> Pedals { get; set; }
        public IEnumerable<PowerMeterType> PowerMeters { get; set; }
        public IEnumerable<ConsoleType> Consoles { get; set; }
        public IEnumerable<SprintShiftType> SprintShifts { get; set; }
        public IEnumerable<ArtworkBeltGuard> ArtworkBeltGuards { get; set; }
        public IEnumerable<ArtworkFlywheel> ArtworkFlywheels { get; set; }
        public IEnumerable<ArtworkFrameFork> ArtworkFrameForks { get; set; }

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
