using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface IFavoritesService
    {
        DataResponse<List<FavoritesDto>> Favourite_Houses(Guid objId);
        PagedDataResponse<FavoritesDto> Favourite_Houses2(CommonListQuery commonListQuery, Guid objId);

        DataResponse<FavoritesDto> Favorites(FavoritesDto dto);

    }
}
