namespace StagesCycling.BLL.Services
{
    using StagesCycling.BLL.Converters;
    using StagesCycling.BLL.DTO;
    using StagesCycling.DAL;
    using StagesCycling.DAL.Entities.Accessories;
    using Interfaces;

    public class AccessoriesService : IAccessoriesService
    {
        private IUnitOfWork _unitOfWork;

        private IGenericRepository<Aerobar> _aerobarRepository;
        private IGenericRepository<StagesBikeNumberPlate> _stagesBikeNumberPlateRepository;
        private IGenericRepository<HandlebarPost> _handlebarPostRepository;
        private IGenericRepository<MediaShelf> _mediaShelfRepository;
        private IGenericRepository<PhoneHolder> _phoneHolderRepository;
        private IGenericRepository<SeatPost> _seatPostRepository;
        private IGenericRepository<StagesDumbbellHolder> _stagesDumbbellHolderRepository;
        private IGenericRepository<TabletHolder> _tabletHolderRepository;


        public AccessoriesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            _aerobarRepository = _unitOfWork.GetRepository<Aerobar>();
            _stagesBikeNumberPlateRepository = _unitOfWork.GetRepository<StagesBikeNumberPlate>();
            _handlebarPostRepository = _unitOfWork.GetRepository<HandlebarPost>();
            _mediaShelfRepository = _unitOfWork.GetRepository<MediaShelf>();
            _phoneHolderRepository = _unitOfWork.GetRepository<PhoneHolder>();
            _seatPostRepository = _unitOfWork.GetRepository<SeatPost>();
            _stagesDumbbellHolderRepository = _unitOfWork.GetRepository<StagesDumbbellHolder>();
            _tabletHolderRepository = _unitOfWork.GetRepository<TabletHolder>();
        }

        public AccessoryList GetAllAccessories()
        {
            var accessoriesList = new AccessoryList()
            {
                StagesBikeNumberPlates = Mapper.MapLists(_stagesBikeNumberPlateRepository.GetAll()),

                Aerobars = Mapper.MapLists(_aerobarRepository.GetAll()),

                HandlebarPosts = Mapper.MapLists(_handlebarPostRepository.GetAll()),

                MediaShelves = Mapper.MapLists(_mediaShelfRepository.GetAll()),

                PhoneHolders = Mapper.MapLists(_phoneHolderRepository.GetAll()),

                SeatPosts = Mapper.MapLists(_seatPostRepository.GetAll()),

                StagesDumbbellHolders = Mapper.MapLists(_stagesDumbbellHolderRepository.GetAll()),

                TabletHolders = Mapper.MapLists(_tabletHolderRepository.GetAll())
            };

            return accessoriesList;
        }
    }
}
