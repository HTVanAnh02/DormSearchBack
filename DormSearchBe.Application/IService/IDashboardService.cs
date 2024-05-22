using DormSearchBe.Domain.Dto.Houses;
using DormSearchBe.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Service.Dashboard
{
    public interface IDashboardService
    {
        public long getTotalHouse();
        public long getTotalUser();
        public long getTotalRating();
        public bool DuyetBaiDang(int id);
        IEnumerable<HousesDto> GetAll();
        IEnumerable<HousesDto> getBaiDangCanDuyet();
        HousesDto GetById(Guid id);
        /*bool Add(HousesDto HousesDto);*/
        bool Update(HousesDto HousesDto);
       /* bool Delete(Guid id);*/
        IEnumerable<HousesDto> getPostbyUserId(int iduser);
    }
}
