using BusinessModel.Models;

namespace BusinessModel.Contracts
{
    public interface IOrderService
    {
        Task<long> AddOrderItem(string userName, Recipe? recipe, int quantity);
        Task<Order?> CurrentOrder(string userName);
        Task<bool> FinishOrder(string userName);
    }
}