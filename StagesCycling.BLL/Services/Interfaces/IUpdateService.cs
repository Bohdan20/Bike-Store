namespace StagesCycling.BLL.Services.Interfaces
{
    using DTO;

    public interface IUpdateService
    {
        #region Accessories
        void UpdateAerobar(UpdateDetail model);
        void UpdateHandlebarPost(UpdateDetail model);
        void UpdateMediaShelf(UpdateDetail model);
        void UpdatePhoneHolder(UpdateDetail model);
        void UpdateSeatPost(UpdateDetail model);
        void UpdateStagesBikeNumberPlate(UpdateDetail model);
        void UpdateStagesDumbbellHolder(UpdateDetail model);
        void UpdateTabletHolder(UpdateDetail model);
        #endregion

        #region Details
        void UpdateConsoleType(UpdateDetail model);
        void UpdateHandlebarType(UpdateDetail model);
        void UpdateModel(UpdateDetail model);
        void UpdatePedalType(UpdateDetail model);
        void UpdatePlasticsColorType(UpdateDetail model);
        void UpdatePowerMeterType(UpdateDetail model);
        void UpdateSeatType(UpdateDetail model);
        void UpdateSprintShiftType(UpdateDetail model);
        #endregion

        void UpdatePrice(UpdatePrice model);
        void UpdateConfiguration(UpdateConfiguration model);
    }
}
