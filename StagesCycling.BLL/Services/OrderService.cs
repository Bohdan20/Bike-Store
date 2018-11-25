namespace StagesCycling.BLL.Services
{
    using StagesCycling.BLL.DTO;
    using StagesCycling.DAL;
    using StagesCycling.DAL.Entities;
    using StagesCycling.DAL.Entities.Base;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using System;
    using Microsoft.AspNet.Identity;


    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;

        private IGenericRepository<OrderDetail> _orderDetailRepository;
        private IGenericRepository<Cycle> _cycleRepository;
        private IGenericRepository<Order> _orderRepository;
        private IGenericRepository<Model> _modelRepository;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _orderDetailRepository = _unitOfWork.GetRepository<OrderDetail>();
            _cycleRepository = _unitOfWork.GetRepository<Cycle>();
            _orderRepository = _unitOfWork.GetRepository<Order>();
            _modelRepository = _unitOfWork.GetRepository<Model>();
        }

        public void AddOrder(OrderToSave model)
        {
            var paintColorId = AddPaintColorToOrder<PaintColor>(model.PaintColorId, model.CustomColor);

            var artworkBeltGuardId = AddArtworkToOrder<ArtworkBeltGuard>(model.ArtworkBeltGuardId,
                model.ArtworkBeltGuardColor, model.ArtworkBeltGuardImageUrl);

            var artworkFlywheelId = AddArtworkToOrder<ArtworkFlywheel>(model.ArtworkFlywheelId,
                model.ArtworkFlywheelColor, model.ArtworkFlywheelImageUrl);

            var artworkFrameForkId = AddArtworkToOrder<ArtworkFrameFork>(model.ArtworkFrameForkId,
                model.ArtworkFrameForkColor, model.ArtworkFrameForkImageUrl);


            var IsChecked = false;

            var detail = new OrderDetail()
            {
                GrossPrice = model.GrossPrice,

                Discount = model.Discount,

                NetPrice = model.NetPrice,

                Comment = model.Comment,

                CustomerName = model.CustomerName,

                CreateSalesOrder = IsChecked,

                DateTimeAdded = DateTime.Now
            };

            _orderDetailRepository.Create(detail);

            var cycle = new Cycle()
            {
                ModelId = GetIdByModelType(model.ModelType),

                HandlebarTypeId = model.HandlebarTypeId,

                PlasticsColorTypeId = model.PlasticsColorTypeId,

                SprintShiftTypeId = model.SprintShiftTypeId,

                PowerMeterTypeId = model.PowerMeterTypeId,

                PedalTypeId = model.PedalTypeId,

                ConsoleTypeId = model.ConsoleTypeId,

                SeatTypeId = model.SeatTypeId,

                PaintColorId = paintColorId,

                ArtworkBeltGuardId = artworkBeltGuardId.Value,

                ArtworkFlywheelId = artworkFlywheelId,

                ArtworkFrameForkId = artworkFrameForkId.Value
            };

            _cycleRepository.Create(cycle);

            var order = new Order()
            {
                TabletHolderId = model.TabletHolderId,
                TabletHolderQuantity = model.TabletHolderQuantity,

                PhoneHolderId = model.PhoneHolderId,
                PhoneHolderQuantity = model.PhoneHolderQuantity,

                MediaShelfId = model.MediaShelfId,
                MediaShelfQuantity = model.MediaShelfQuantity,

                SeatPostId = model.SeatPostId,
                SeatPostQuantity = model.SeatPostQuantity,

                HandlebarPostId = model.HandlebarPostId,
                HandlebarPostQuantity = model.HandlebarPostQuantity,

                StagesDumbbellHolderId = model.StagesDumbbellHolderId,
                StagesDumbbellHolderQuantity = model.StagesDumbbellHolderQuantity,

                ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),

                AerobarQuantity = model.AerobarQuantity,
                AerobarId = model.AerobarId,

                PlatesOneToSixtyId = model.PlatesOneToSixtyId,
                PlatesOneToSixtyQuntity = model.PlatesOneToSixtyQuntity,

                PlatesSixtyOneToHundredId = model.PlatesSixtyOneToHundredId,
                PlatesSixtyOneToHundredQuantity = model.PlatesSixtyOneToHundredQuantity,

                PlatesOneToEightyId = model.PlatesOneToEightyId,
                PlatesOneToEightyQuantity = model.PlatesOneToEightyQuantity,

                PlatesFiftyPeacesId = model.PlatesFiftyPeacesId,
                PlatesFiftyPeacesQuantity = model.PlatesFiftyPeacesQuantity,

                PlatesOneToThirtyId = model.PlatesOneToThirtyId,
                PlatesOneToThirtyQuantity = model.PlatesOneToThirtyQuantity,

                CycleQuantity = model.CycleQuantity
            };

            _orderRepository.Create(order);

            _unitOfWork.Save();
        }

        private long GetIdByModelType(string model)
        {
            IEnumerable<Model> models = _modelRepository.Get(m => m.Title == model);
            var id = models.FirstOrDefault().Id;
            return id;
        }

        private long? AddPaintColorToOrder<T>(long? standartId, string color) where T : PaintColor, new()
        {
            long? id;

            var priceRepository = _unitOfWork.GetRepository<BasePrice>();

            var basePriceId = priceRepository.Entities
                .Where(p => p.Type.Contains("Custom" + typeof(T).Name)).FirstOrDefault().Id;

            if (color == null)
            {
                id = standartId;
            }
            else
            {
                var paintColorRepository = _unitOfWork.GetRepository<T>();
                
                var paintColor = new T()
                {
                    Title = color,
                    BasePriceId = basePriceId,
                    Sourcing = "Giant"
                };

                var paintColorEntity = paintColorRepository.Create(paintColor);

                _unitOfWork.Save();

                id = paintColorEntity.Id;
            }

            return id;
        }

        private long? AddArtworkToOrder<T>(long? standartId, string color, string imageUrl) where T : ArtworkEntity, new()
        {
            long? id;

            var priceRepository = _unitOfWork.GetRepository<BasePrice>();

            var basePriceId = priceRepository.Entities
               .Where(p => p.Type.Contains("Custom" + typeof(T).Name)).FirstOrDefault().Id;

            if (color == null && imageUrl == null)
            {
                id = standartId;
            }
            else
            {
                var _artworkRepository = _unitOfWork.GetRepository<T>();

                var artwork = new T()
                {
                    Title = typeof(T).Name + " Customer Provided Art",
                    CustomColor = color,
                    CustomImageUrl = imageUrl,
                    BasePriceId = basePriceId,
                    Sourcing = "Giant"
                };

                var artworkEntity = _artworkRepository.Create(artwork);

                _unitOfWork.Save();

                id = artworkEntity.Id;
            }

            return id;
        }
    }
}
