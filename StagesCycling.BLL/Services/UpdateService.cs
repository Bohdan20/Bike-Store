namespace StagesCycling.BLL.Services
{
    using System;

    using DTO;
    using Interfaces;
    using DAL;
    using DAL.Entities;
    using DAL.Entities.Accessories;

    public class UpdateService : IUpdateService
    {
        private IUnitOfWork _unitOfWork;

        public UpdateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void UpdatePrice(UpdatePrice model)
        {
            var repo = _unitOfWork.GetRepository<BasePrice>();
            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.Price.HasValue)
            {
                itemToUpdate.Price = model.Price.Value;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateConfiguration(UpdateConfiguration model)
        {
            var repo = _unitOfWork.GetRepository<OrderConfiguration>();
            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.MaxDiscount.HasValue)
            {
                itemToUpdate.MaxDiscount = model.MaxDiscount.Value;
            }

            if (model.MinBikeQuantity.HasValue)
            {
                itemToUpdate.MinBikeQuantity = model.MinBikeQuantity.Value;
            }
            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateAerobar(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<Aerobar>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateHandlebarPost(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<HandlebarPost>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateMediaShelf(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<MediaShelf>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdatePhoneHolder(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<PhoneHolder>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateSeatPost(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<SeatPost>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateStagesBikeNumberPlate(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<StagesBikeNumberPlate>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateStagesDumbbellHolder(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<StagesDumbbellHolder>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateTabletHolder(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<TabletHolder>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateConsoleType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<ConsoleType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateHandlebarType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<HandlebarType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateModel(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<Model>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdatePedalType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<PedalType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdatePlasticsColorType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<PlasticsColorType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdatePowerMeterType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<PowerMeterType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateSeatType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<SeatType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }

        public void UpdateSprintShiftType(UpdateDetail model)
        {
            var repo = _unitOfWork.GetRepository<SprintShiftType>();

            var itemToUpdate = repo.Get(model.Id);

            if (itemToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            if (model.BasePrice.HasValue)
            {
                itemToUpdate.BasePrice = model.BasePrice.Value;

            }

            if (!String.IsNullOrEmpty(model.Title))
            {
                itemToUpdate.Title = model.Title;
            }

            repo.Update(itemToUpdate);
            _unitOfWork.Save();
        }
    }
}
