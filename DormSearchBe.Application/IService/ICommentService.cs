using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface ICommentService
    {
        DataResponse<object> FindAll(string id);
        DataResponse<CommentDTO> CreateComment(CommentDTO comment);
        DataResponse<commentDescriptionDTO> CreateCommenDescriptiont(commentDescriptionDTO commentDescriptionDTOs);

    }
}
