namespace StagesCycling.BLL.DTO
{
    using DAL.Entities;
    using DAL.Entities.Accessories;

    public class OptionsToEdit
    {
        public EditItem<BasePrice> BasePrices { get; set; }
        public EditItem<OrderConfiguration> OrderConfigurations { get; set; }

        #region Details

        public EditItem<Model> Models { get; set; }

        public EditItem<PlasticsColorType> PlasticsColors { get; set; }
        public EditItem<SeatType> Seats { get; set; }
        public EditItem<HandlebarType> Handlebars { get; set; }
        public EditItem<PedalType> Pedals { get; set; }
        public EditItem<PowerMeterType> PowerMeters { get; set; }
        public EditItem<ConsoleType> Consoles { get; set; }
        public EditItem<SprintShiftType> SprintShifts { get; set; }
        public EditItem<ArtworkBeltGuard> ArtworkBeltGuards { get; set; }
        public EditItem<ArtworkFlywheel> ArtworkFlywheels { get; set; }
        public EditItem<ArtworkFrameFork> ArtworkFrameForks { get; set; }

        #endregion

        #region Accessories

        public EditItem<StagesBikeNumberPlate> StagesBikeNumberPlates { get; set; }
        public EditItem<Aerobar> Aerobars { get; set; }
        public EditItem<HandlebarPost> HandlebarPosts { get; set; }
        public EditItem<MediaShelf> MediaShelves { get; set; }
        public EditItem<PhoneHolder> PhoneHolders { get; set; }
        public EditItem<SeatPost> SeatPosts { get; set; }
        public EditItem<StagesDumbbellHolder> StagesDumbbellHolders { get; set; }
        public EditItem<TabletHolder> TabletHolders { get; set; }

        #endregion
    }
}
