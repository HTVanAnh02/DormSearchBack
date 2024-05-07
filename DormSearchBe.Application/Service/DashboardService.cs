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

        public IEnumerable<HousesDto> getBaiDangCanDuyet()
        {
            throw new NotImplementedException();
        }

        public bool DuyetBaiDang(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoanhThuTheoTuan> getDoanhThuTheoTuan()
        {
            throw new NotImplementedException();
        }
        /* public IEnumerable<HousesDto> getBaiDangCanDuyet()
{
    return _housesService.GetAllBaiDangCanDuyet();
}

public bool DuyetBaiDang(Guid id)
{
    var find = _housesService.GetById(id);
    if (find == null)
        return false;
    find.TrangThai = 1;
    if (!_OrderService.Update(find)) return false;
    return true;
}
public bool setDonHangDangGiao(int id)
{
    var find = _OrderService.GetById(id);
    if (find == null)
        return false;
    find.TrangThai = 2;
    if (!_OrderService.Update(find)) return false;
    return true;
}
public DoanhThuTheoTuan getDoanhThuTheoTuan()
{
    DateTime currentDate = DateTime.Now;
    DateTime startOfWeek = currentDate.Date.AddDays(-(int)currentDate.DayOfWeek);
    DoanhThuTheoTuan doanhThuTuan = new DoanhThuTheoTuan();
    for (int i = 0; i < 7; i++)
    {
        DateTime currentDay = startOfWeek.AddDays(i);

        long totalRevenue = _OrderService.GetAll()
            .Where(order => order.NgayDat.Date == currentDay.Date)
            .Sum(order => order.Total);

        // Gán giá trị doanh thu cho từng ngày trong tuần
        switch (currentDay.DayOfWeek)
        {
            case DayOfWeek.Monday:
                doanhThuTuan.T2 = totalRevenue;
                break;
            case DayOfWeek.Tuesday:
                doanhThuTuan.T3 = totalRevenue;
                break;
            case DayOfWeek.Wednesday:
                doanhThuTuan.T4 = totalRevenue;
                break;
            case DayOfWeek.Thursday:
                doanhThuTuan.T5 = totalRevenue;
                break;
            case DayOfWeek.Friday:
                doanhThuTuan.T6 = totalRevenue;
                break;
            case DayOfWeek.Saturday:
                doanhThuTuan.T7 = totalRevenue;
                break;
            case DayOfWeek.Sunday:
                doanhThuTuan.CN = totalRevenue;
                break;
        }
    }
    return doanhThuTuan;
}
public IEnumerable<SoLuongTheoTrangThaiDonHang> getSoLuongDonHangTheoTrangThai()
{
    var TrangThaiDonHangList = _orderrepository.GetAll().Select(x => x.TrangThai).Distinct();
    var ketqua = new List<SoLuongTheoTrangThaiDonHang>();
    foreach (var item in TrangThaiDonHangList)
    {
        var tentrangthai = "";
        switch (item)
        {
            case -1:
                tentrangthai = "Hủy";
                break;
            case 0:
                tentrangthai = "Chờ duyệt";
                break;
            case 1:
                tentrangthai = "Đang chuẩn bị";
                break;
            case 2:
                tentrangthai = "Đang giao";
                break;
            case 3:
                tentrangthai = "Hoàn thành";
                break;
        }
        var soluong = _orderrepository.GetAll().Count(x => x.TrangThai == item);
        ketqua.Add(new SoLuongTheoTrangThaiDonHang
        {
            TenTrangThai = tentrangthai,
            Value = soluong
        });
    }
    return ketqua;
}
*/

    }
}
