namespace StagesCycling.BLL.Services.Interfaces
{
    using StagesCycling.BLL.DTO;
    using System.Collections.Generic;

    public interface IConfigurationService
    {
        IEnumerable<Configuration> GetAllConfigurations();
        void Check(long id);
        SavedOrder GetSavedOrder(long orderId);
    }
}
