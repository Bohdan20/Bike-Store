namespace StagesCycling.BLL.DTO
{
    using StagesCycling.DAL.Entities;
    using System.Collections.Generic;

    public class DetailList
    {
        public decimal BasePriceSC2 { get; set; }
        public decimal BasePriceSC3 { get; set; }
        public decimal CustomBeltGuardPrice { get; set; }
        public decimal CustomFrameforkPrice { get; set; }
        public decimal CustomFlywheelPrice { get; set; }
        public decimal CustomColorPrice { get; set; }

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
    }
}