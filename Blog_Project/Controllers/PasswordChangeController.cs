using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Project.Models;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AdminUser> _userManager;

        public PasswordChangeController(UserManager<AdminUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Mail);
            if (user == null)
            {
                // E-posta ile ilişkili kullanıcı bulunamadı, hata mesajı göster ve başka bir işlem yapmasını sağla
                ModelState.AddModelError("", "Bu e-posta ile ilişkili kullanıcı bulunamadı.");
                return View();
            }
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user); // token oluşturacak
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Flei", "fleizeanblog@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgotPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            string bodyContent = "Selam " + user.Name + ",\n\nŞifrenizi değiştirmek için bir istekte bulunmuştunuz!\n\nBu talebi siz yapmadıysanız, lütfen bu epostayı dikkate almayın.\n\nAksi takdirde, şifrenizi değiştirmek için lütfen bu bağlantıyı kullanın: ";

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = bodyContent + passwordResetTokenLink;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("fleizeanblog@gmail.com", "taqyrqgrukqtaopz");
            client.Send(mimeMessage);
            client.Disconnect(true);



            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;


            

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];

            if (userid == null || token == null)
            {

            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}

