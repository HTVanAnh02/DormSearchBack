using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface INotificationService
    {
        PagedDataResponse<NotificationQuery> Items(CommonListQuery commonList, Guid id);
        DataResponse<List<NotificationDto>> ItemsList();
        DataResponse<NotificationQuery> Create(NotificationDto dto);
        DataResponse<NotificationQuery> Update(NotificationDto dto);
        DataResponse<NotificationQuery> Delete(Guid id);
        DataResponse<NotificationQuery> GetById(Guid id);
    }
}
