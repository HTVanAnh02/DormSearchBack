using DormSearchBe.Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormSearchBe.Api.Controllers.Thongke
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongkeController : ControllerBase
    {
        private readonly IThongkeService _thongkeService;
        public ThongkeController(IThongkeService thongkeService)
        {
            _thongkeService = thongkeService;
        }

        [HttpGet]
        [Route(nameof(thongKeDienTich))]
        public IActionResult thongKeDienTich()
        {
            return Ok(_thongkeService.totalDienTich());
        }

        [HttpGet]
        [Route(nameof(thongkeThanhPho))]
        public IActionResult thongkeThanhPho()
        {
            return Ok(_thongkeService.totalCity());
        }

        [HttpGet]
        [Route(nameof(thongkeVungMien))]
        public IActionResult thongkeVungMien()
        {
            return Ok(_thongkeService.totalMien());
        }

        [HttpGet]
        [Route(nameof(totalBanTinGiaTien))]
        public IActionResult totalBanTinGiaTien()
        {
            return Ok(_thongkeService.totalGiaTien());
        }

        [HttpGet]
        [Route(nameof(totalBanTinDienTich))]
        public IActionResult totalBanTinDienTich()
        {
            return Ok(_thongkeService.totalDienTich());
        }
    }
}
