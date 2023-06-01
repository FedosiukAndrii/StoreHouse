using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public SizeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }
    }
}
