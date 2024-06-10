using DormSearchBe.Application.IService;
using DormSearchBe.Domain.Dto.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DormSearchBe.Api.Controllers.Comment
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route(nameof(CreateComment))]
        public IActionResult CreateComment(CommentDTO commentDTO)
        {
            return Ok(_commentService.CreateComment(commentDTO));
        }

        [HttpPost]
        [Route(nameof(CreateCommentDescription))]
        public IActionResult CreateCommentDescription(commentDescriptionDTO commentDescriptionDTOs)
        {
            return Ok(_commentService.CreateCommenDescriptiont(commentDescriptionDTOs));
        }

        [HttpGet]
        [Route(nameof(FindAll))]
        public IActionResult FindAll(string id)
        {
            return Ok(_commentService.FindAll(id));
        }
    }
}
