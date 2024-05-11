using Microsoft.AspNetCore.Http;

namespace StoreHouse.Models.ViewModels;

public class ColorImagesVM
{
    public int ColorId { get; set; }
    public List<IFormFile> Images { get; set; }
}
