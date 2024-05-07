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
        public IEnumerable<HousesDto> getBaiDangCanDuyet();
        public bool DuyetBaiDang(int id);
        public IEnumerable<DoanhThuTheoTuan> getDoanhThuTheoTuan();


    }
}
