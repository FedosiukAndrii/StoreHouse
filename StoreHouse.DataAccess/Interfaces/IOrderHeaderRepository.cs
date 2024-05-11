using StoreHouse.Models.Entities;
namespace StoreHouse.DataAccess.Interfaces;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    public IQueryable<OrderHeader> Orders { get;}
    Task Update (OrderHeader orderHeader);
	Task UpdateStatus(int orderId, string orderStatus, string paymentStatus = null);
	Task UpdateStripePaymetId(int orderId, string sessionId, string paymetnId);
}
