using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Domain.Dto.Favorites;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Infrastructure.Exceptions;
using DormSearchBe.Infrastructure.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DormSearchBe.Api.Controllers.Favorites
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService _favoriteHouseService;
        public FavoritesController(IFavoritesService favouriteJobService)
        {
            _favoriteHouseService = favouriteJobService;
        }
        [HttpGet("Favourite_House")]
        public IActionResult Favourite_House()
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            return Ok(_favoriteHouseService.Favourite_Houses(Guid.Parse(objId)));
        }
        [HttpPost("FavoriteHouse")]
        public IActionResult FavoriteHouse(FavoritesHouse dto)
        {
            var objId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (objId == null)
            {
                throw new ApiException(HttpStatusCode.FORBIDDEN, HttpStatusMessages.Forbidden);
            }
            var favorites = new FavoritesDto();
            if (dto.FavoriteHouseId == "")
            {
                favorites.FavoriteHouseId = new Guid();
            }
            else
            {
                favorites.FavoriteHouseId = Guid.Parse(dto.FavoriteHouseId);
            }
            favorites.IsFavorites = Boolean.Parse(dto.IsFavorite_House);
            favorites.HousesId = Guid.Parse(dto.HouseId);
            favorites.UserId = Guid.Parse(objId);
            return Ok(_favoriteHouseService.Favorites(favorites));
        }
    }
}
