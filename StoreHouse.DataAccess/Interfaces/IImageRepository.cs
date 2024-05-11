using StoreHouse.Models.Entities;
namespace StoreHouse.DataAccess.Interfaces;

public interface IImageRepository : IRepository<ProductColorImage>
{
    public Task AddRange(IEnumerable<ProductColorImage> images);
}
