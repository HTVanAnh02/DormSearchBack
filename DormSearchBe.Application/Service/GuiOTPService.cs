using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Wrappers.Concrete;
using DormSearchBe.Domain.BaseModel;
using DormSearchBe.Domain.Dto.Areas;
using DormSearchBe.Domain.Dto.Otp;
using DormSearchBe.Domain.EmailConfig;
using DormSearchBe.Domain.Entity;
using DormSearchBe.Infrastructure.Context;
using DormSearchBe.Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormSearchBe.Application.Service
{
    public class GuiOTPService : IGuiOTPService
    {
        private readonly DormSearch_DbContext _context;
        private readonly string key = "QWERTYUIOPASFDGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890";
        private Random random = new Random();
        private readonly EmailSetting _emaiSetting;
        public GuiOTPService(DormSearch_DbContext context, IOptions<EmailSetting> emailSetting)
        {
            _context = context;
            _emaiSetting = emailSetting.Value;
        }
        public DataResponse<string> DeleteToken(string email)
        {
            try
            {
                var checkEmail = _context.Users.Where(x => x.Email == email).FirstOrDefault();
                if(checkEmail == null)
                {
                    return new DataResponse<string>("Email NUll", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
                }

                var checkEmailInOTP = _context.GuiOtps.Where(x => x.Email_id == checkEmail.UserId).ToList();

                _context.GuiOtps.RemoveRange(checkEmailInOTP);
                if(_context.SaveChanges() > 0)
                {
                    return new DataResponse<string>("Delete Success", HttpStatusCode.OK, HttpStatusMessages.OK);
                }

                return new DataResponse<string>("Delete Faild", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
            catch(Exception ex)
            {
                return new DataResponse<string>(ex.Message, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
        }

        public DataResponse<string> guiOTP(string email)
        {
            try
            {
                var checkEmai = _context.Users.Where(x => x.Email == email && x.deletedAt == null).FirstOrDefault();
                if (checkEmai == null)
                {
                    return new DataResponse<string>("Email Null", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
                }

                var guiOtp = new GuiOTP
                {
                    Id = Guid.NewGuid(),
                    otp = randomOTP(5),
                    Email_id = checkEmai.UserId,
                    users = checkEmai,
                    createdAt = DateTime.Now,
                };

                _context.GuiOtps.Add(guiOtp);
                if(_context.SaveChanges() > 0)
                {
                    string body = $"Hello {checkEmai.FullName}, mã xác nhận của bạn là {guiOtp.otp}";
                    SendEmai(email, "Gửi OTP", body);
                    return new DataResponse<string>(email ?? checkEmai.UserId.ToString(), HttpStatusCode.OK, HttpStatusMessages.OK);
                }

                return new DataResponse<string>("Gửi Faild", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
            catch(Exception ex) {
                return new DataResponse<string>(ex.Message, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
        }

        public async Task SendEmai(string emai, string tieude, string body)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emaiSetting.SenderName, _emaiSetting.SenderEmail));
            message.To.Add(new MailboxAddress("", emai));
            message.Subject = tieude;
            message.Body = new TextPart("html")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emaiSetting.SmtpServer, _emaiSetting.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emaiSetting.Username, _emaiSetting.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

        private string randomOTP(int leng)
        {
            leng = leng <= 0 ? 5 : leng;

            StringBuilder str = new StringBuilder();
            for(var i = 0; i < leng; i++)
            {
                char kytu = key[random.Next(key.Length)];
                while(str.ToString().Contains(kytu)) // Kiểm tra nếu như ký tự đã tồn tại
                {
                    kytu = key[random.Next(key.Length)];
                }

                str.Append(kytu);
            }

            return str.ToString();
        }

        public DataResponse<string> UpdatePassword(updatePassword updatePasswords)
        {
            try
            {
                var checkEmail = _context.Users.Where(x => x.Email == updatePasswords.email && x.deletedAt == null).FirstOrDefault();
                var checkOTP = _context.GuiOtps.Where(x => x.otp == updatePasswords.token).OrderByDescending(x => x.createdAt).FirstOrDefault();

                if(checkEmail == null || checkOTP == null)
                {
                    return new DataResponse<string>("Email Or OTP NULL", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
                }

                if(checkEmail.UserId != checkOTP.Email_id)
                {
                    return new DataResponse<string>("Email không khớp", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
                }

                checkEmail.Password = PasswordHelper.CreateHashedPassword(updatePasswords.password);

                _context.Users.Update(checkEmail);
                if(_context.SaveChanges() > 0)
                {
                    var checkTokenDeleteAll = _context.GuiOtps.Where(x => x.Email_id == checkOTP.Email_id).ToList();
                    _context.GuiOtps.RemoveRange(checkTokenDeleteAll);
                    if(_context.SaveChanges() > 0)
                    {
                        return new DataResponse<string>("Success", HttpStatusCode.OK, HttpStatusMessages.OK);
                    }

                    return new DataResponse<string>("Delete Token Faild", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
                }

                return new DataResponse<string>("Faild", HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
            catch(Exception ex)
            {
                return new DataResponse<string>(ex.Message, HttpStatusCode.BAD_REQUEST, HttpStatusMessages.UpdatedError);
            }
        }
    }
}
