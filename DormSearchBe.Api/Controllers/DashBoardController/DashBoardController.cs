using DormSearchBe.Service.Dashboard;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormSearchBe.Api.Controllers.DashBoardController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashboardService _DashboardService;
        public DashBoardController(IDashboardService iDashboardService)
        {
            _DashboardService = iDashboardService;
        }
        [HttpGet("getTotalUser")]
        public IActionResult getAccountClient()
        {
            return Ok(_DashboardService.getTotalUser());
        }
        [HttpGet("getTotalHouse")]
        public IActionResult getTotalHouse()
        {
            return Ok(_DashboardService.getTotalHouse());
        }
        [HttpGet("getBaiDangCanDuyet")]
        public IActionResult getBaiDangCanDuyet()
        {
            return Ok(_DashboardService.getBaiDangCanDuyet());
        }
        
        [HttpPost("DuyetBaiDang")]
        public IActionResult DuyetBaiDang(List<int> listOrderId)
        {
            foreach (var i in listOrderId)
            {
                if (!_DashboardService.DuyetBaiDang(i))
                    return BadRequest();
            }
            return Ok("Duyệt thành công");
        }
        
    }
}
