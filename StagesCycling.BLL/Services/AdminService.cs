namespace StagesCycling.BLL.Services
{
    using System.Linq;

    using DTO;
    using DAL;
    using DAL.Entities;
    using Converters;
    using Services.Interfaces;
    using DAL.Entities.Base;
    using DAL.Entities.Accessories;

    public class AdminService : IAdminService
    {
        private IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OptionsToEdit GetAllItems()
        {
            var options = new OptionsToEdit()
            {
                OrderConfigurations = GetOptions<OrderConfiguration>(),

                BasePrices = GetOptions<BasePrice>(),

                Models = GetOptions<Model>(),

                PlasticsColors = GetOptions<PlasticsColorType>(),

                Seats = GetOptions<SeatType>(),

                Handlebars = GetOptions<HandlebarType>(),

                Pedals = GetOptions<PedalType>(),

                PowerMeters = GetOptions<PowerMeterType>(),

                Consoles = GetOptions<ConsoleType>(),

                SprintShifts = GetOptions<SprintShiftType>(),

                ArtworkBeltGuards = GetArtworkOptions<ArtworkBeltGuard>(),

                ArtworkFlywheels = GetArtworkOptions<ArtworkFlywheel>(),

                ArtworkFrameForks = GetArtworkOptions<ArtworkFrameFork>(),

                StagesBikeNumberPlates = GetOptions<StagesBikeNumberPlate>(),

                Aerobars = GetOptions<Aerobar>(),

                HandlebarPosts = GetOptions<HandlebarPost>(),

                MediaShelves = GetOptions<MediaShelf>(),

                PhoneHolders = GetOptions<PhoneHolder>(),

                SeatPosts = GetOptions<SeatPost>(),

                StagesDumbbellHolders = GetOptions<StagesDumbbellHolder>(),

                TabletHolders = GetOptions<TabletHolder>()
            };

            return options;
        }

        private EditItem<T> GetOptions<T>() where T : BaseEntity
        {
            var repository = _unitOfWork.GetRepository<T>();
            var items = Mapper.MapLists(repository.GetAll());

            var editItem = new EditItem<T>()
            {
                Items = items,
                ItemType = typeof(T).Name
            };

            return editItem;
        }

        private EditItem<T> GetArtworkOptions<T>() where T : ArtworkEntity
        {
            var repository = _unitOfWork.GetRepository<T>();
            var items = Mapper.MapLists(repository.GetAll()).Where(a => a.BasePrice.Type.Contains(typeof(T).Name));

            var editItem = new EditItem<T>()
            {
                Items = items,
                ItemType = typeof(T).Name
            };

            return editItem;
        }
    }
}

