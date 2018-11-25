namespace StagesCycling.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using StagesCycling.BLL.DTO;
    using StagesCycling.BLL.Services.Interfaces;
    using StagesCycling.DAL;
    using StagesCycling.DAL.Entities;
    using StagesCycling.DAL.Entities.Accessories;
    using StagesCycling.DAL.Entities.Base;
    using Microsoft.AspNet.Identity;
    using System.Web;

    public class ConfigurationService : IConfigurationService
    {
        private IUnitOfWork _unitOfWork;

        private IGenericRepository<Order> _orderRepository;

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _orderRepository = _unitOfWork.GetRepository<Order>();
        }

        public IEnumerable<Configuration> GetAllConfigurations()
        {
            var configurations = new List<Configuration>();
            var strCurrentUserId = HttpContext.Current.User.Identity.GetUserId();

            var orderEntities = _orderRepository.GetAll().Where(o => o.ApplicationUserId == strCurrentUserId);

            foreach (var item in orderEntities)
            {
                var configuration = new Configuration()
                {
                    ConfigNumber = item.Id,
                    Customer = item.OrderDetail.CustomerName ?? string.Format("{0} {1}", item.ApplicationUser.FirstName, item.ApplicationUser.LastName),
                    Comment = item.OrderDetail.Comment,
                    GrossPrice = item.OrderDetail.GrossPrice,
                    Discount = item.OrderDetail.Discount,
                    NetPrice = item.OrderDetail.NetPrice,
                    Timestamp = item.OrderDetail.DateTimeAdded,
                    CreateSalesOrder = item.OrderDetail.CreateSalesOrder
                };

                configurations.Add(configuration);
            }

            return configurations;
        }

        public void Check(long id)
        {
            var orderItem = _orderRepository.Get(id);
            orderItem.OrderDetail.CreateSalesOrder = !orderItem.OrderDetail.CreateSalesOrder;
            _orderRepository.Update(orderItem);
            _unitOfWork.Save();
        }

        public SavedOrder GetSavedOrder(long orderId)
        {
            var order = _orderRepository.Get(orderId);

            var savedOrder = new SavedOrder()
            {
                SavedItems = GetSavedOrderDetails(orderId),
                Discount = order.OrderDetail.Discount,
                NetPrice = order.OrderDetail.NetPrice
            };

            return savedOrder;
        }

        private IEnumerable<SavedItem> GetSavedOrderDetails(long orderId)
        {
            var order = _orderRepository.Get(orderId);
            var cycleQuantity = order.CycleQuantity;

            var savedOrder = new List<SavedItem>();
    
            var model = GetSavedItem<Model>(order.Cycle.ModelId);
            AddQuantity(model, cycleQuantity);
            AddToList(model, savedOrder);

            var artworkBeltGuard = GetSavedArtwork<ArtworkBeltGuard>(order.Cycle.ArtworkBeltGuardId);
            AddQuantity(artworkBeltGuard, cycleQuantity);
            AddToList(artworkBeltGuard, savedOrder);


            var artworkFlywheel = GetSavedArtwork<ArtworkFlywheel>(order.Cycle.ArtworkFlywheelId);
            AddQuantity(artworkFlywheel, cycleQuantity);
            AddToList(artworkFlywheel, savedOrder);

            var artworkFrameFork = GetSavedArtwork<ArtworkFrameFork>(order.Cycle.ArtworkFrameForkId);
            AddQuantity(artworkFrameFork, cycleQuantity);
            AddToList(artworkFrameFork, savedOrder);

            var console = GetSavedItem<ConsoleType>(order.Cycle.ConsoleTypeId);
            AddQuantity(console, cycleQuantity);
            AddToList(console, savedOrder);

            var handlebar = GetSavedItem<HandlebarType>(order.Cycle.HandlebarTypeId);
            AddQuantity(handlebar, cycleQuantity);
            AddToList(handlebar, savedOrder);

            var paintColor = GetSavedPaintColor<PaintColor>(order.Cycle.PaintColorId);
            AddQuantity(paintColor, cycleQuantity);
            AddToList(paintColor, savedOrder);

            var pedal = GetSavedItem<PedalType>(order.Cycle.PedalTypeId);
            AddQuantity(pedal, cycleQuantity);
            AddToList(pedal, savedOrder);

            var plasticsColor = GetSavedItem<PlasticsColorType>(order.Cycle.PlasticsColorTypeId);
            AddQuantity(plasticsColor, cycleQuantity);
            AddToList(plasticsColor, savedOrder);

            var powerMeter = GetSavedItem<PowerMeterType>(order.Cycle.PowerMeterTypeId);
            AddQuantity(powerMeter, cycleQuantity);
            AddToList(powerMeter, savedOrder);

            var seat = GetSavedItem<SeatType>(order.Cycle.SeatTypeId);
            AddQuantity(seat, cycleQuantity);
            AddToList(seat, savedOrder);

            var sprintShift = GetSavedItem<SprintShiftType>(order.Cycle.SprintShiftTypeId);
            AddQuantity(sprintShift, cycleQuantity);
            AddToList(sprintShift, savedOrder);

            var aerobar = GetSavedItem<Aerobar>(order.AerobarId);
            AddQuantity(aerobar, order.AerobarQuantity);
            AddToList(aerobar, savedOrder);

            var handlebarPost = GetSavedItem<HandlebarPost>(order.HandlebarPostId);
            AddQuantity(handlebarPost, order.HandlebarPostQuantity);
            AddToList(handlebarPost, savedOrder);

            var mediaShelf = GetSavedItem<MediaShelf>(order.MediaShelfId);
            AddQuantity(mediaShelf, order.MediaShelfQuantity);
            AddToList(mediaShelf, savedOrder);

            var phoneHolder = GetSavedItem<PhoneHolder>(order.PhoneHolderId);
            AddQuantity(phoneHolder, order.PhoneHolderQuantity);
            AddToList(phoneHolder, savedOrder);

            var seatPost = GetSavedItem<SeatPost>(order.SeatPostId);
            AddQuantity(seatPost, order.SeatPostQuantity);
            AddToList(seatPost, savedOrder);

            var stagesDumbbellHolder = GetSavedItem<StagesDumbbellHolder>(order.StagesDumbbellHolderId);
            AddQuantity(stagesDumbbellHolder, order.StagesDumbbellHolderQuantity);
            AddToList(stagesDumbbellHolder, savedOrder);

            var tabletHolder = GetSavedItem<TabletHolder>(order.TabletHolderId);
            AddQuantity(tabletHolder, order.TabletHolderQuantity);
            AddToList(tabletHolder, savedOrder);

            var platesOneToSixty = GetSavedItem<StagesBikeNumberPlate>(order.PlatesOneToSixtyId);
            AddQuantity(platesOneToSixty, order.PlatesOneToSixtyQuntity);
            AddToList(platesOneToSixty, savedOrder);

            var platesSixtyOneToHundred = GetSavedItem<StagesBikeNumberPlate>(order.PlatesSixtyOneToHundredId);
            AddQuantity(platesSixtyOneToHundred, order.PlatesSixtyOneToHundredQuantity);
            AddToList(platesSixtyOneToHundred, savedOrder);

            var platesOneToEighty = GetSavedItem<StagesBikeNumberPlate>(order.PlatesOneToEightyId);
            AddQuantity(platesOneToEighty, order.PlatesOneToEightyQuantity);
            AddToList(platesOneToEighty, savedOrder);

            var platesFiftyPeaces = GetSavedItem<StagesBikeNumberPlate>(order.PlatesFiftyPeacesId);
            AddQuantity(platesFiftyPeaces, order.PlatesFiftyPeacesQuantity);
            AddToList(platesFiftyPeaces, savedOrder);

            var platesOneToThirty = GetSavedItem<StagesBikeNumberPlate>(order.PlatesOneToThirtyId);
            AddQuantity(platesOneToThirty, order.PlatesOneToThirtyQuantity);
            AddToList(platesOneToThirty, savedOrder);

            return savedOrder;
        }

        private SavedItem GetSavedItem<T>(long? id) where T : AccessoryEntity
        {
            SavedItem savedOrder;

            if (!id.HasValue)
            {
                savedOrder = null;
            }
            else
            {
                var repo = _unitOfWork.GetRepository<T>();
                var entity = repo.Get(id.Value);

                savedOrder = new SavedItem()
                {
                    Title = entity.Title,
                    Sourcing = entity.Sourcing,
                    SKU = entity.SKU,
                    BasePrice = entity.BasePrice
                };
            }
            return savedOrder;
        }

        private SavedItem GetSavedArtwork<T>(long? id) where T : ArtworkEntity
        {
            SavedItem savedOrder;

            if (!id.HasValue)
            {
                savedOrder = null;
            }
            else
            {
                var repo = _unitOfWork.GetRepository<T>();

                var entity = repo.Get(id.Value);

                savedOrder = new SavedItem()
                {
                    Title = entity.Title ?? entity.CustomImageUrl,
                    Sourcing = entity.Sourcing,
                    SKU = entity.SKU,
                    BasePrice = entity.BasePrice.Price
                };
            }
            return savedOrder;
        }

        private SavedItem GetSavedPaintColor<T>(long? id) where T : PaintColor
        {
            SavedItem savedOrder;

            if (!id.HasValue)
            {
                savedOrder = null;
            }
            else
            {
                var repo = _unitOfWork.GetRepository<T>();

                var entity = repo.Get(id.Value);

                savedOrder = new SavedItem()
                {
                    Title = entity.Title,
                    Sourcing = entity.Sourcing,
                    SKU = entity.SKU,
                    BasePrice = entity.BasePrice.Price
                };
            }
            return savedOrder;
        }

        private void AddQuantity(SavedItem item, int quantity)
        {
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        private void AddToList(SavedItem item, List<SavedItem> list)
        {
            if (item != null)
            {
                list.Add(item);
            }
        }
    }
}
