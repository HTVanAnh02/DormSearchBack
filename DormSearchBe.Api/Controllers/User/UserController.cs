using CloudinaryDotNet.Core;
using DormSearchBe.Application.Helpers;
using DormSearchBe.Application.IService;
using DormSearchBe.Application.Service;
using DormSearchBe.Domain.Dto.Role;
using DormSearchBe.Domain.Dto.User;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using DormSearchBe.Domain.Dto.Otp;

namespace DormSearchBe.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IGuiOTPService _guiOtpService;
        public UserController(IUserService userService, IGuiOTPService guiOtpService)
        {
            _userService = userService;
            _guiOtpService = guiOtpService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] CommonListQuery query)
        {
            return Ok(_userService.Items(query));
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserDto dto)
        {
            return Ok(_userService.Create(dto));
        }
        [HttpPost("QuenPassword")]
        public IActionResult QuenPassword(string username,string email)
        {
            var accountClient = _userService.GetAll().Where(x => x.Email.Equals(username)).FirstOrDefault();
            if (accountClient == null)
            {
                return BadRequest("tài khoản ko có");
            }
            try
            {
                var code = new Random().Next(100000, 999999).ToString();
                MailMessage message = new MailMessage();
                message.From = new MailAddress(email);
                message.To.Add(username);
                message.Subject = "Quên mật khẩu";
                message.Body = "Mã xác minh là: " + code;
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("hoangthivananh22122002@gmail.com", "thzfyhcvpsgnapvl");
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
                var codePass = new RouteValueDictionary();
                codePass.Add("code", code);
                codePass.Add("email", username);
                return Ok(new
                {
                    Code = code,
                    Username = username
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("DoiMatKhau")]
        public IActionResult DoiMatKhau(DoiMatKhau model)
        {
            var acoount = _userService.GetAll().Where(x => x.Email.Equals(model.Email)).FirstOrDefault();
            if (acoount == null)
            {
                return BadRequest("tài khoản ko có");
            }
            acoount.Password = maHoaMatKhau(model.NewPass);
            if (_userService.UpdatePass(acoount))
            {
                return Ok("Thành công. Vui lòng bạn đăng nhập");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route(nameof(DeleteAllOTPs))]
        public IActionResult DeleteAllOTPs(string email)
        {
            return Ok(_guiOtpService.DeleteToken(email));
        }

        [HttpPut]
        [Route(nameof(UpdatePassword))]
        public IActionResult UpdatePassword(updatePassword updatePasswords)
        {
            return Ok(_guiOtpService.UpdatePassword(updatePasswords));
        }

        [HttpPost]
        [Route(nameof(GuiOTP))]
        public IActionResult GuiOTP(string email)
        {
            return Ok(_guiOtpService.guiOTP(email));
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromForm] UserDto dto)
        {
            return Ok(_userService.Update(dto));
        }
        
        private readonly string hash = @"foxle@rn";
        private string maHoaMatKhau(string text)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_userService?.Delete(id));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_userService.GetById(id));
        }
    }
}
