using Microsoft.AspNetCore.Mvc.Rendering;
using StoreHouse.Models.Entities;
using System.Security.Claims;

namespace StoreHouse.Models.Utils
{
    public static class Extension
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<Category> categories) =>
            categories?.OrderBy(c => c.Order).Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.CategoryId.ToString()
            });
        public static IEnumerable<SelectListItem> ToSelectListItems(this IEnumerable<Color> colors) =>
            colors.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.ColorId.ToString()
            });

        public static string GetId(this ClaimsPrincipal claims)
        {
			var claimsIdentity = (ClaimsIdentity)claims.Identity;
			return claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
		}
    }
}
