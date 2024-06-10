using DormSearchBe.Application.Wrappers.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface IThongkeService
    {
        DataResponse<int> totalTongBaiDang();
        DataResponse<Dictionary<string, int>> totalMien();
        DataResponse<Dictionary<string, int>> totalCity();
        DataResponse<Dictionary<string, long>> totalDienTich();
        DataResponse<Dictionary<string, long>> totalGiaTien();


    }
}
