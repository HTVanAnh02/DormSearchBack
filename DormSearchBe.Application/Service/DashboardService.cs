using DormSearchBe.Application.IService;
using DormSearchBe.Domain.Dto.Houses;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Service.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Houses> _houseRepository;
        private readonly IGenericRepository<Ratings> _ratingRepository;
        private readonly IHousesService _housesService;
        public DashboardService
         (
          IGenericRepository<User> userRepository,
          IGenericRepository<Houses> houseRepository,
          IGenericRepository<Ratings> ratingRepository,
          IHousesService housesService
         )
        {
            _userRepository = userRepository;
            _houseRepository = houseRepository;
            _ratingRepository = ratingRepository;
            _housesService = housesService;
        }
        public long getTotalHouse()
        {
            return _houseRepository.GetAllData().Count();
        }
        public long getTotalUser()
        {
            return _userRepository.GetAllData().Count();
        }
        public long getTotalRating()
        {
            return _ratingRepository.GetAllData().Count();
       
        }
        public bool DuyetBaiDang(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HousesDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HousesDto> getBaiDangCanDuyet()
        {
            throw new NotImplementedException();
        }

        public HousesDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Update(HousesDto HousesDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HousesDto> getPostbyUserId(int iduser)
        {
            throw new NotImplementedException();
        }
        /*public IEnumerable<HousesDto> getBaiDangCanDuyet()
{
   return _housesService.getBaiDangCanDuyet();
}
public bool DuyetDonHang(Guid id)
{
   var find=_housesService.GetById(id);
   if (find == null)
       return false;
   find.TrangThai = 1;
   if(!_housesService.Update(find)) return false;
   return true;
}
public bool setDonHangDangGiao(Guid id)
{
   var find = _housesService.GetById(id);
   if (find == null)
       return false;
   find.TrangThai = 2;
   if (!_housesService.Update(find)) return false;
   return true;
}
*/
    }
}
