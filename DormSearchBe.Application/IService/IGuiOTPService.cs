using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.Dto.Otp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.IService
{
    public interface IGuiOTPService
    {
        DataResponse<string> guiOTP(string email);
        DataResponse<string> UpdatePassword(updatePassword updatePasswords);
        DataResponse<string> DeleteToken(string email);

    }
}
