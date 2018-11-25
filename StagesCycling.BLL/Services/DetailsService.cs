namespace StagesCycling.BLL.Services
{
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using StagesCycling.BLL.DTO;
    using StagesCycling.DAL;
    using StagesCycling.DAL.Entities;
    using Converters;
    using Interfaces;
    using System.Web.Hosting;
    using System.Web;
    using System.Drawing;
    using System.IO;
    using System;
    using StagesCycling.DAL.Entities.Base;

    public class DetailsService : IDetailsService
    {
        private IUnitOfWork _unitOfWork;

        private IGenericRepository<BasePrice> _basePriceRepository;
        private IGenericRepository<Model> _modelRepository;
        private IGenericRepository<PaintColor> _paintColorRepository;
        private IGenericRepository<PlasticsColorType> _plasticsColorRepository;
        private IGenericRepository<SeatType> _seatRepository;
        private IGenericRepository<HandlebarType> _handlebarRepository;
        private IGenericRepository<PedalType> _pedalRepository;
        private IGenericRepository<PowerMeterType> _powerMeterRepository;
        private IGenericRepository<ConsoleType> _consoleRepository;
        private IGenericRepository<SprintShiftType> _sprintShiftRepository;

        private IGenericRepository<ArtworkBeltGuard> _artworkBeltGuardRepository;
        private IGenericRepository<ArtworkFlywheel> _artworkFlywheelRepository;
        private IGenericRepository<ArtworkFrameFork> _artworkFrameForkRepository;


        public DetailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _basePriceRepository = _unitOfWork.GetRepository<BasePrice>();
            _modelRepository = _unitOfWork.GetRepository<Model>();
            _paintColorRepository = _unitOfWork.GetRepository<PaintColor>();
            _plasticsColorRepository = _unitOfWork.GetRepository<PlasticsColorType>();
            _seatRepository = _unitOfWork.GetRepository<SeatType>();
            _handlebarRepository = _unitOfWork.GetRepository<HandlebarType>();
            _pedalRepository = _unitOfWork.GetRepository<PedalType>();
            _consoleRepository = _unitOfWork.GetRepository<ConsoleType>();
            _powerMeterRepository = _unitOfWork.GetRepository<PowerMeterType>();
            _sprintShiftRepository = _unitOfWork.GetRepository<SprintShiftType>();

            _artworkBeltGuardRepository = _unitOfWork.GetRepository<ArtworkBeltGuard>();
            _artworkFlywheelRepository = _unitOfWork.GetRepository<ArtworkFlywheel>();
            _artworkFrameForkRepository = _unitOfWork.GetRepository<ArtworkFrameFork>();
        }

        public DetailList GetAllDetails()
        {
            var TitleSC2 = "SC2"; // here better change to post
            var TitleSC3 = "SC3";

            var detailsList = new DetailList()
            {
                BasePriceSC2 = _modelRepository.Get(m => m.Title == TitleSC2).FirstOrDefault().BasePrice,

                BasePriceSC3 = _modelRepository.Get(m => m.Title == TitleSC3).FirstOrDefault().BasePrice,

                CustomBeltGuardPrice = _basePriceRepository.Get(b => b.Type.Contains("CustomArtworkBeltGuard")).FirstOrDefault().Price,

                CustomFrameforkPrice = _basePriceRepository.Get(b => b.Type.Contains("CustomArtworkFrameFork")).FirstOrDefault().Price,

                CustomFlywheelPrice = _basePriceRepository.Get(b => b.Type.Contains("CustomArtworkFlywheel")).FirstOrDefault().Price,

                CustomColorPrice = _basePriceRepository.Get(b => b.Type.Contains("CustomPaintColor")).FirstOrDefault().Price,

                PaintColors = GetColorImages(),
                
                PlasticsColors = GetOptions<PlasticsColorType>(),
                
                Seats = GetOptions<SeatType>(),

                Handlebars = GetOptions<HandlebarType>(),
                
                Pedals = GetOptions<PedalType>(),

                PowerMeters = GetOptions<PowerMeterType>(),

                Consoles = Mapper.MapLists(_consoleRepository.GetAll()),

                SprintShifts = Mapper.MapLists(_sprintShiftRepository.GetAll()),

                ArtworkBeltGuards = Mapper.MapLists(_artworkBeltGuardRepository.GetAll().Where(a => a.BasePrice.Type.Contains("StandartArtworkBeltGuard"))),

                ArtworkFlywheels = Mapper.MapLists(_artworkFlywheelRepository.GetAll().Where(a => a.BasePrice.Type.Contains("StandartArtworkFlywheel"))),

                ArtworkFrameForks = Mapper.MapLists(_artworkFrameForkRepository.GetAll().Where(a => a.BasePrice.Type.Contains("StandartArtworkFrameFork")))

            };

            return detailsList;
        }

        private List<PaintColor> GetColorImages()
        {
            var paintColors = Mapper.MapLists(_paintColorRepository.GetAll().Where(p => p.BasePrice.Type.Contains("StandartPaintColor")));

            var scheme = HttpContext.Current.Request.Url.Scheme;
            var hostName = HttpContext.Current.Request.Url.Host;
            var port = HttpContext.Current.Request.Url.Port;
            var host = scheme + "://" + hostName + ":" + port;

            foreach (var item in paintColors)
            {
                item.ColorImageUrl = $"{host}/Content/ColorPictures/" + item.ColorImageUrl;
                item.BikeImageUrl = $"{host}/Content/ColorPictures/" + item.BikeImageUrl;
            }
            return paintColors;
        }

        private List<T> GetOptions<T>() where T: AccessoryEntity
        {
            var repository = _unitOfWork.GetRepository<T>();
            var detail = Mapper.MapLists(repository.GetAll());

            var scheme = HttpContext.Current.Request.Url.Scheme;
            var hostName = HttpContext.Current.Request.Url.Host;
            var port = HttpContext.Current.Request.Url.Port;
            var host = scheme + "://" + hostName + ":" + port;

            foreach (var item in detail)
            {
                item.ImageUrl = $"{host}/Content/DetailsAccessoriesPictures/" + item.ImageUrl;
            }
            return detail;
        }
    }
}
