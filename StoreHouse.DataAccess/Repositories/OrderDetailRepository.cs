using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
	{
        private readonly ApplicationDbContext _dbContex;

        public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }
	}
}
