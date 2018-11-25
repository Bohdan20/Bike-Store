namespace StagesCycling.BLL.Services.Interfaces
{
    using StagesCycling.BLL.DTO;

    public interface IOrderService
    {
        void AddOrder(OrderToSave order);
    }
}
