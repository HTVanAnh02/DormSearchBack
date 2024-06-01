using AutoMapper;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Chat;
using DormSearchBe.Domain.Dto.City;
using DormSearchBe.Domain.Dto.Message;
using DormSearchBe.Domain.Dto.Messages;
using DormSearchBe.Domain.Dto.User;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Domain.Repositories;
using DormSearchBe.Infrastructure.Exceptions;
using DormSearchBe.Infrastructure.Repositories;
using DormSearchBe.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DormSearchBe.Application.Service
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _messagesRepository;
        private readonly IMapper _mapper;
        private readonly IChatGroupRepository _chatGroupRepository;
        private readonly IUserRepository _userRepository;
        public MessagesService(IMessagesRepository messageRepository, IMapper mapper, IChatGroupRepository chatGroupRepository,IUserRepository userRepository)
        {
            _messagesRepository = messageRepository;
            _mapper = mapper;
            _chatGroupRepository = chatGroupRepository;
            _userRepository = userRepository;
        }

        public DataResponse<List<ChatQuery>> ChatGroupById(Guid id)
        {
            var chatGroups = _chatGroupRepository.GetAllData().Where(x => x.UserSend_Id == id).ToList();
            var chatGroupDtos = _mapper.Map<List<Chat_GroupDto>>(chatGroups);

            var userIds = chatGroups.Select(x => x.UserId).Distinct().ToList();

            var users = userIds.Select(userId => _mapper.Map<UserDto>(_userRepository.GetById(userId))).ToList();

            var query = from chat in chatGroupDtos
                        join user in users on chat.UserId equals user.UserId
                        select new ChatQuery
                        {
                            Chat_Group_Id = chat.Chat_Group_Id,
                            Avatar = user.Avatar,
                            FullName = user.FullName,
                            UserId = chat.UserId,
                            UserSend_Id = chat.UserSend_Id,
                        };

            var result = query.ToList();

            return new DataResponse<List<ChatQuery>>(result, HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public DataResponse<MessageQuery> GetById(Guid id)
        {
            var item = _messagesRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<MessageQuery>(_mapper.Map<MessageQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<MessageQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<MessageQuery>>(_messagesRepository.GetAllData());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.Message.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<MessageQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<MessageQuery>(paginatedResult, 200, query.Count());
        }


        /*  public DataResponse<List<ChatMessDto>> ItemsList(Guid id,Guid UserId)
          {
              var mess = _messagesRepository.GetAllData().Where(x=>x.UserId==UserId && x.UserSend==id).ToList();
              var users = _userRepository.GetAllData();
              var query = from m in mess
                          join
                         u in users on m.UserId equals u.UserId
                          select new ChatMessDto
                          {
                              Avatar=u.Avatar,
                              FullName=u.FullName,
                              Messages=m.Messages,
                              MessagesId=m.MessagesId,
                              UserId=m.UserId,
                              UserSend=m.UserSend,
                          };


              var result = query.ToList();
              return new DataResponse<List<ChatMessDto>>(result, HttpStatusCode.OK, HttpStatusMessages.OK);

              *//* if (query != null && query.Any())
               {
                   return new DataResponse<List<ChatMessDto>>(_mapper.Map<List<ChatMessDto>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
               }*//*
              throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
          }*/
        public DataResponse<List<ChatMessDto>> ItemsList(Guid id, Guid userId)
        {
            var messages = _messagesRepository.GetAllData()
                                              .Where(x => x.UserId == userId && x.UserSend == id)
                                              .ToList();

            if (!messages.Any())
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }

            var userIds = messages.Select(m => m.UserId).Distinct().ToList();
            var users = userIds.Select(userId => _mapper.Map<UserDto>(_userRepository.GetById(userId))).ToList();


            var query = from m in messages
                        join u in users on m.UserId equals u.UserId
                        select new ChatMessDto
                        {
                            Avatar = u.Avatar,
                            FullName = u.FullName,
                            Messages = m.Messages,
                            MessagesId = m.MessagesId,
                            UserId = m.UserId,
                            UserSend = m.UserSend,
                        };

            var result = query.ToList();
            return new DataResponse<List<ChatMessDto>>(result, HttpStatusCode.OK, HttpStatusMessages.OK);
        }


        public DataResponse<MessageDto> Send(MessageDto dto)
        {
            dto.MessagesId = Guid.NewGuid();
            var check=_chatGroupRepository.GetAllData().Where(x=>x.UserId==dto.UserId);
            if(!check.Any())
            {
                var group = new Chat_Group()
                {
                    UserId = dto.UserId,
                    Chat_Group_Id = Guid.NewGuid(),
                    UserSend_Id = dto.UserSend.Value
                };
                _chatGroupRepository.Create(group);
            }
            var newData = _messagesRepository .Create(_mapper.Map<Message>(dto));
            if (newData != null)
            {
                return new DataResponse<MessageDto>(_mapper.Map<MessageDto>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }
    }
}
