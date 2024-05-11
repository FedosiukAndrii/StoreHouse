using StoreHouse.DataAccess.Data;
using StoreHouse.DataAccess.Interfaces;
using StoreHouse.Models.Entities;

namespace StoreHouse.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContex;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContex = dbContext;
        }


    }
}
