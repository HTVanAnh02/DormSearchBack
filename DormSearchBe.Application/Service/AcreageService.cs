using AutoMapper;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Acreage;
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
    public class AcreageService : IAcreageService
    {
        private readonly IAcreageRepository _areasRepository;
        private readonly IMapper _mapper;

        public AcreageService(IAcreageRepository areasRepository, IMapper mapper)
        {
            _areasRepository = areasRepository;
            _mapper = mapper;
        }

        public DataResponse<AcreageQuery> Create(AcreageDto dto)
        {
            dto.AcreageId = Guid.NewGuid();
            var newData = _areasRepository.Create(_mapper.Map<Acreage>(dto));
            if (newData != null)
            {
                return new DataResponse<AcreageQuery>(_mapper.Map<AcreageQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.AddedError);
        }

        public DataResponse<AcreageQuery> Delete(Guid id)
        {
            var item = _areasRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var data = _areasRepository.Delete(id);
            if (data != null)
            {
                return new DataResponse<AcreageQuery>(_mapper.Map<AcreageQuery>(item), HttpStatusCode.OK, HttpStatusMessages.DeletedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.DeletedError);
        }

        public DataResponse<AcreageQuery> GetById(Guid id)
        {
            var item = _areasRepository.GetById(id);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            return new DataResponse<AcreageQuery>(_mapper.Map<AcreageQuery>(item), HttpStatusCode.OK, HttpStatusMessages.OK);
        }

        public PagedDataResponse<AcreageQuery> Items(CommonListQuery commonList)
        {
            var query = _mapper.Map<List<AcreageQuery>>(_areasRepository.GetAllData());
            if (!string.IsNullOrEmpty(commonList.keyword))
            {
                query = query.Where(x => x.Acreages.Contains(commonList.keyword)).ToList();
            }
            var paginatedResult = PaginatedList<AcreageQuery>.ToPageList(query, commonList.page, commonList.limit);
            return new PagedDataResponse<AcreageQuery>(paginatedResult, 200, query.Count());
        }

        public DataResponse<List<AcreageDto>> ItemsList()
        {
            var query = _areasRepository.GetAllData();
            if (query != null && query.Any())
            {
                var AcreageDtos = _mapper.Map<List<AcreageDto>>(query);
                return new DataResponse<List<AcreageDto>>(_mapper.Map<List<AcreageDto>>(query), HttpStatusCode.OK, HttpStatusMessages.OK);
            }
            throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
        }


        public DataResponse<AcreageQuery> Update(AcreageDto dto)
        {
            var item = _areasRepository.GetById(dto.AcreageId);
            if (item == null)
            {
                throw new ApiException(HttpStatusCode.ITEM_NOT_FOUND, HttpStatusMessages.NotFound);
            }
            var newData = _areasRepository.Update(_mapper.Map(dto, item));
            if (newData != null)
            {
                return new DataResponse<AcreageQuery>(_mapper.Map<AcreageQuery>(newData), HttpStatusCode.OK, HttpStatusMessages.UpdatedSuccessfully);
            }
            throw new ApiException(HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
        }
    }
}
