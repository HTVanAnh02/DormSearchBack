using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Chat;
using DormSearchBe.Domain.Dto.Message;
using DormSearchBe.Domain.Dto.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface IMessagesService
    {
        PagedDataResponse<MessageQuery> Items(CommonListQuery commonList);
        DataResponse<List<ChatMessDto>> ItemsList(Guid id,Guid UserId);
        DataResponse<List<ChatQuery>> ChatGroupById(Guid id);
        DataResponse<MessageDto> Send(MessageDto dto);

    }
}
