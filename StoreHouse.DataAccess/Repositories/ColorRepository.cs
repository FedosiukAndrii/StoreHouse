using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class ColorRepository : RepositoryBase<Color>, IColorRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }
    }
}
