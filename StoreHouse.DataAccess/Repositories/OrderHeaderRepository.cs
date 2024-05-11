using Microsoft.EntityFrameworkCore;
using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class OrderHeaderRepository : RepositoryBase<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public OrderHeaderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }

		public IQueryable<OrderHeader> Orders => _dbContex
			.OrderHeaders
			.Include(i => i.ApplicationUser);

		public async Task Update(OrderHeader orderHeader)
		{
			 _dbContex.OrderHeaders.Update(orderHeader);
			await _dbContex.SaveChangesAsync();
		}

		public async Task UpdateStatus(int orderId, string orderStatus, string paymentStatus = null)
		{
			var order = await _dbContex.OrderHeaders.FirstOrDefaultAsync(u => u.Id == orderId);
			if(order != null) 
			{ 
				order.OrderStatus = orderStatus;
				order.PaymentStatus = paymentStatus ?? order.PaymentStatus;
			}
            await _dbContex.SaveChangesAsync();
        }

        public async Task UpdateStripePaymetId(int orderId, string sessionId, string paymetnId)
		{
			var order = await _dbContex.OrderHeaders.FirstOrDefaultAsync(u => u.Id == orderId);
			if(!string.IsNullOrEmpty(sessionId))
			{
				order.SessionId = sessionId;
			}
			if(!string.IsNullOrEmpty(paymetnId))
			{
				order.PaymentIntentId = paymetnId;
				order.OrderDate = DateTime.Now;
			}

			await _dbContex.SaveChangesAsync();
		}
	}
}
