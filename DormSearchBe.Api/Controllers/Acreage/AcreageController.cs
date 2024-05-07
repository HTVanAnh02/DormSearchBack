using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Domain.Dto.Acreage;
using Microsoft.AspNetCore.Mvc;

namespace DormSearchBe.Api.Controllers.Acreage
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcreageController : ControllerBase
    {
        private readonly IAcreageService _areasService;
        public AcreageController(IAcreageService AcreageService)
        {
            _areasService = AcreageService;
        }
        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            return Ok(_areasService.Items(query));
        }

        [HttpPost]
        public IActionResult Create(AcreageDto dto)
        {
            return Ok(_areasService.Create(dto));
        }

        [HttpPatch("{id}")]
        public IActionResult Update(AcreageDto dto)
        {
            return Ok(_areasService.Update(dto));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_areasService?.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_areasService.GetById(id));
        }
        [HttpGet("ItemsList")]
        public IActionResult ItemsList()
        {
            return Ok(_areasService.ItemsList());
        }
    }
}
