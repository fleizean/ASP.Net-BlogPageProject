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

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Flei", "ayarlanmali@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgotPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            string bodyContent = "<!DOCTYPE html><html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" lang=\"en\"><head><title></title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><meta name=\"viewport\" content=\"width=device-width,initial-scale=1\"><!--[if mso]><xml><o:officedocumentsettings><o:pixelsperinch>96</o:pixelsperinch><o:allowpng></o:officedocumentsettings></xml><![endif]--><style>*{box-sizing:border-box}body{margin:0;padding:0}a[x-apple-data-detectors]{color:inherit!important;text-decoration:inherit!important}#MessageViewBody a{color:inherit;text-decoration:none}p{line-height:inherit}.desktop_hide,.desktop_hide table{mso-hide:all;display:none;max-height:0;overflow:hidden}.image_block img+div{display:none}@media (max-width:660px){.desktop_hide table.icons-inner{display:inline-block!important}.icons-inner{text-align:center}.icons-inner td{margin:0 auto}.social_block.desktop_hide .social-table{display:inline-block!important}.row-content{width:100%!important}.stack .column{width:100%;display:block}.mobile_hide{max-width:0;min-height:0;max-height:0;font-size:0;display:none;overflow:hidden}.desktop_hide,.desktop_hide table{max-height:none!important;display:table!important}}</style></head><body style=\"text-size-adjust:none;background-color:#f8f8f9;margin:0;padding:0\"><table class=\"nl-container\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;background-color:#f8f8f9\"><tbody><tr><td><table class=\"row row-1\" align=\"center\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;background-color:#1aa19c\"><tbody><tr><td><table class=\"row-content stack\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;color:#000;background-color:#1aa19c;width:640px;margin:0 auto\" width=\"640\"><tbody><tr><td class=\"column column-1\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0;text-align:left;font-weight:400;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0\"><table class=\"divider_block block-1\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\"><div class=\"alignment\" align=\"center\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"divider_inner\" style=\"font-size:1px;line-height:1px;border-top:4px solid #1aa19c\"><span>&#8202;</span></td></tr></table></div></td></tr></table></td></tr></tbody></table></td></tr></tbody></table><table class=\"row row-2\" align=\"center\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tbody><tr><td><table class=\"row-content stack\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;color:#000;width:640px;margin:0 auto\" width=\"640\"><tbody><tr><td class=\"column column-1\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0;text-align:left;font-weight:400;padding-bottom:5px;padding-top:5px;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0\"><table class=\"empty_block block-1\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\"><div></div></td></tr></table></td></tr></tbody></table></td></tr></tbody></table><table class=\"row row-3\" align=\"center\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tbody><tr><td><table class=\"row-content stack\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;color:#000;background-color:#fff;width:640px;margin:0 auto\" width=\"640\"><tbody><tr><td class=\"column column-1\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0;text-align:left;font-weight:400;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0\"><table class=\"image_block block-1\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\" style=\"width:100%\"><div class=\"alignment\" align=\"center\" style=\"line-height:10px\"><img src=\"https://d1oco4z2z1fhwp.cloudfront.net/templates/default/4036/___passwordreset.gif\" style=\"height:auto;display:block;border:0;max-width:640px;width:100%\" width=\"640\" alt=\"Image of lock &amp; key.\" title=\"Image of lock &amp; key.\"></div></td></tr></table><table class=\"divider_block block-2\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\" style=\"padding-top:30px\"><div class=\"alignment\" align=\"center\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"divider_inner\" style=\"font-size:1px;line-height:1px;border-top:0 solid #bbb\"><span>&#8202;</span></td></tr></table></div></td></tr></table><table class=\"text_block block-3\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;word-break:break-word\"><tr><td class=\"pad\" style=\"padding-bottom:10px;padding-left:40px;padding-right:40px;padding-top:10px\"><div style=\"font-family:Arial,sans-serif\"><div class style=\"font-size:12px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;mso-line-height-alt:14.399999999999999px;color:#555;line-height:1.2\"><p style=\"margin:0;font-size:16px;text-align:center;mso-line-height-alt:19.2px\"><span style=\"font-size:30px;color:#2b303a\"><strong>Şifreni mi unutmuştun?</strong></span></p></div></div></td></tr></table><table class=\"text_block block-4\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;word-break:break-word\"><tr><td class=\"pad\" style=\"padding-bottom:10px;padding-left:40px;padding-right:40px;padding-top:10px\"><div style=\"font-family:sans-serif\"><div class style=\"font-size:12px;font-family:Montserrat,Trebuchet MS,Lucida Grande,Lucida Sans Unicode,Lucida Sans,Tahoma,sans-serif;mso-line-height-alt:18px;color:#555;line-height:1.5\"><p style=\"margin:0;font-size:14px;text-align:center;mso-line-height-alt:22.5px\"><span style=\"color:#808389;font-size:15px\">Selam " + user.Name + ", üzülme hemen ekiplerimiz sana yardıma koştu ve bize bulunduğun istek sonucunda sana bir şifre sıfırlama imkanı sunuyoruz.</span></p></div></div></td></tr></table><table class=\"button_block block-5\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\" style=\"padding-left:10px;padding-right:10px;padding-top:15px;text-align:center\"><div class=\"alignment\" align=\"center\"><!--[if mso]><v:roundrect xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:w=\"urn:schemas-microsoft-com:office:word\" href=\"" + passwordResetTokenLink + "\" style=\"height:62px;width:155px;v-text-anchor:middle\" arcsize=\"57%\" stroke=\"false\" fillcolor=\"#f7a50c\"><w:anchorlock><v:textbox inset=\"0px,0px,0px,0px\"><center style=\"color:#fff;font-family:Arial,sans-serif;font-size:16px\"><![endif]--><a href=\"" + passwordResetTokenLink + "\" target=\"_blank\" style=\"text-decoration:none;display:inline-block;color:#fff;background-color:#f7a50c;border-radius:35px;width:auto;border-top:0 solid transparent;font-weight:undefined;border-right:0 solid transparent;border-bottom:0 solid transparent;border-left:0 solid transparent;padding-top:15px;padding-bottom:15px;font-family:'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:16px;text-align:center;mso-border-alt:none;word-break:keep-all\"><span style=\"padding-left:30px;padding-right:30px;font-size:16px;display:inline-block;letter-spacing:normal\"><span style=\"margin:0;word-break:break-word;line-height:32px\"><strong>Şifreyi Sıfırla</strong></span></span></a><!--[if mso]><![endif]--></div></td></tr></table><table class=\"divider_block block-6\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\" style=\"padding-bottom:12px;padding-top:60px\"><div class=\"alignment\" align=\"center\"><table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"divider_inner\" style=\"font-size:1px;line-height:1px;border-top:0 solid #bbb\"><span>&#8202;</span></td></tr></table></div></td></tr></table></td></tr></tbody></table></td></tr></tbody></table><table class=\"row row-4\" align=\"center\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tbody><tr><td><table class=\"row-content stack\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;color:#000;background-color:#410125;width:640px;margin:0 auto\" width=\"640\"><tbody><tr><td class=\"column column-1\" width=\"100%\" style=\"mso-table-lspace:0;mso-table-rspace:0;text-align:left;font-weight:400;vertical-align:top;border-top:0;border-right:0;border-bottom:0;border-left:0\"><table class=\"social_block block-1\" width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0\"><tr><td class=\"pad\" style=\"padding-bottom:10px;padding-left:10px;padding-right:10px;padding-top:28px;text-align:center\"><div class=\"alignment\" align=\"center\"><table class=\"social-table\" width=\"104px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace:0;mso-table-rspace:0;display:inline-block\"><tr><td style=\"padding:0 10px 0 10px\"><a href=\"https://www.twitter.com/onlyflei\" target=\"_blank\"><img src=\"https://app-rsrc.getbee.io/public/resources/social-networks-icon-sets/t-outline-circle-white/twitter@2x.png\" width=\"32\" height=\"32\" alt=\"Twitter\" title=\"Twitter\" style=\"height:auto;display:block;border:0\"></a></td><td style=\"padding:0 10px 0 10px\"><a href=\"https://www.instagram.com/fleizean\" target=\"_blank\"><img src=\"https://app-rsrc.getbee.io/public/resources/social-networks-icon-sets/t-outline-circle-white/instagram@2x.png\" width=\"32\" height=\"32\" alt=\"Instagram\" title=\"Instagram\" style=\"height:auto;display:block;border:0\"></a></td></tr></table></div></td></tr></table></td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></body></html>";
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = bodyContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ayarlanmali@gmail.com", "ayarlanmali");
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

