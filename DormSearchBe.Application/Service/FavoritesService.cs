using AutoMapper;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Favorites;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Domain.Repositories;
using DormSearchBe.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.Service
{
    public class FavoritesHouseService : IFavoritesService
    {
        private readonly IFavoritesRepository _favorites_HouseRepository;
        private readonly IMapper _mapper;
        private readonly IHousesRepository _houseRepository;
        public FavoritesHouseService(IFavoritesRepository favorites_HouseRepository, IMapper mapper, IHousesRepository houseRepository)
        {
            _favorites_HouseRepository = favorites_HouseRepository;
            _mapper = mapper;
            _houseRepository = houseRepository;
        }

        public DataResponse<FavoritesDto> Favorites(FavoritesDto dto)
        {
            throw new NotImplementedException();
        }

        public DataResponse<FavoritesDto> Favourite(FavoritesDto dto)
        {
            var obj = new Favorites();
            var isFavourite = _favorites_HouseRepository.GetAllData().Where(x => x.FavoritesId == dto.FavoriteHouseId && x.HousesId == dto.HousesId).FirstOrDefault();
            if (isFavourite == null)
            {
                obj = _favorites_HouseRepository.Create(_mapper.Map<Favorites>(dto));
            }
            else
            {
                obj = _favorites_HouseRepository.Update(_mapper.Map<Favorites>(dto));
            }
            return new DataResponse<FavoritesDto>(_mapper.Map<FavoritesDto>(obj), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);

        }

        public DataResponse<List<FavoritesDto>> Favourite_Houses(Guid objId)
        {
            throw new NotImplementedException();
        }

        public PagedDataResponse<FavoritesDto> Favourite_Houses2(CommonListQuery commonListQuery, Guid objId)
        {
            throw new NotImplementedException();
        }

        public DataResponse<List<FavoritesDto>> Favourite_Jobs(Guid objId)
        {
            var query = _favorites_HouseRepository.GetAllData().Where(x => x.HousesId == objId);
            return new DataResponse<List<FavoritesDto>>(_mapper.Map<List<FavoritesDto>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);

        }

        public PagedDataResponse<FavoritesDto> Favourite_Jobs2(CommonListQuery commonListQuery, Guid objId)
        {
            var query = _mapper.Map<List<FavoritesDto>>(_favorites_HouseRepository.GetAllData().Where(x => x.HousesId == objId));
            var total = _houseRepository.GetAllData().Count();
            commonListQuery.limit = total;
            var paginatedResult = PaginatedList<FavoritesDto>.ToPageList(query, commonListQuery.page, commonListQuery.limit);
            return new PagedDataResponse<FavoritesDto>(paginatedResult, 200, query.Count());
        }

    }
}    