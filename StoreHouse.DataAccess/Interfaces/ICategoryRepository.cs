using StoreHouse.Models.Entities;
namespace StoreHouse.DataAccess.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    public Task Update(Category category);
}
