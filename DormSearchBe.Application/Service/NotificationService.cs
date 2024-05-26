using AutoMapper;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Notification;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Domain.Repositories;
using DormSearchBe.Infrastructure.Exceptions;
using DormSearchBe.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.Service
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IHousesRepository _houseRepository;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper, IUserRepository userRepository, IHousesRepository houseRepository)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _houseRepository = houseRepository;
        }
        public DataResponse<NotificationQuery> Create(NotificationDto dto)
        {
            dto.NotificationId = Guid.NewGuid();
            var nameHouse = _houseRepository.GetById(dto.HouseId);
            var nameUser = _userRepository.GetById(dto.UserId);
            dto.Message = $"{nameUser.FullName} đã đăng thông tin " + $"{nameHouse.HousesName} này";
            var newData = _notificationRepository.Create(_mapper.Map<Notification>(dto));
            if (newData != null)
            {
                return new DataResponse<NotificationQuery>(_mapper.Map<NotificationQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }

        public DataResponse<NotificationQuery> Delete(Guid id)
        {
            var item = _notificationRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _notificationRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<NotificationQuery>(_mapper.Map<NotificationQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<NotificationQuery> GetById(Guid id)
        {
            var item = _notificationRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<NotificationQuery>(_mapper.Map<NotificationQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<NotificationQuery> Items(CommonListQuery commonList, Guid id)
        {
            var query = _mapper.Map<List<NotificationQuery>>(_notificationRepository.GetAllData().Where(x => x.UserId == id  == null));

            var paginatedResult = PaginatedList<NotificationQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<NotificationQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<List<NotificationDto>> ItemsList()
        {
            var query = _notificationRepository.GetAllData();
            if (query != null && query.Any())
            {
                var cityDtos = _mapper.Map<List<NotificationDto>>(query);
                return new DataResponse<List<NotificationDto>>(_mapper.Map<List<NotificationDto>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
        }

        public DataResponse<List<NotificationQuery>> ItemsListByEmployer(Guid id)
        {
            var query = _notificationRepository.GetAllData();
            if (query != null && query.Any())
            {
                var cityDtos = _mapper.Map<List<NotificationDto>>(query);
                return new DataResponse<List<NotificationQuery>>(_mapper.Map<List<NotificationQuery>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
        }

        public DataResponse<List<NotificationQuery>> ItemsListByUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<NotificationQuery> Update(NotificationDto dto)
        {
            var item = _notificationRepository.GetById(dto.NotificationId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _notificationRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<NotificationQuery>(_mapper.Map<NotificationQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }
    }
}
