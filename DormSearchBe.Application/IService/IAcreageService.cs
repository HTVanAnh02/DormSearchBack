using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Acreage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface IAcreageService
    {
        PagedDataResponse<AcreageQuery> Items(CommonListQuery commonList);
        DataResponse<List<AcreageDto>> ItemsList();
        DataResponse<AcreageQuery> Create(AcreageDto dto);
        DataResponse<AcreageQuery> Update(AcreageDto dto);
        DataResponse<AcreageQuery> Delete(Guid id);
        DataResponse<AcreageQuery> GetById(Guid id);
    }
}
