using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blog_Project.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
/*  using MailKit.Net.Smtp;
using MailKit;
using MimeKit;*/

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog_Project.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<AdminUser> _userManager;

		public ProfileController(UserManager<AdminUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel model = new UserEditViewModel();
			model.Name = values.Name;
			model.Surname = values.Surname;
			model.PictureUrl = values.ImageUrl;
			model.Email = values.Email;
			model.Username = values.UserName;
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel p)
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Picture != null)
			{
                
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(p.Picture.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userimage/" + imagename;
				var stream = new FileStream(savelocation, FileMode.Create);
				await p.Picture.CopyToAsync(stream);

                if (!string.IsNullOrEmpty(user.ImageUrl)) // image önceden mevcutsa silinecek
                {
                    var existingImagePath = Path.Combine(resource, "wwwroot/userimage", user.ImageUrl);
                    if (System.IO.File.Exists(existingImagePath))
                    {
                        System.IO.File.Delete(existingImagePath);
                    }
                }

                user.ImageUrl = imagename;
                

                user.Name = string.IsNullOrEmpty(p.Name) ? user.Name : p.Name;
				user.Surname = string.IsNullOrEmpty(p.Surname) ? user.Surname : p.Surname;
				user.Email = string.IsNullOrEmpty(p.Email) ? user.Email : p.Email;

				if (!string.IsNullOrEmpty(p.Password) && p.Password == p.PasswordConfirm)
				{
					user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
					if (TryValidateModel(user))
					{
						var resultone = await _userManager.UpdateAsync(user);
						if (resultone.Succeeded)
						{
							return RedirectToAction("Index", "Profile");
						}
					}
				}
				var resulttwo = await _userManager.UpdateAsync(user);
				if (resulttwo.Succeeded)
				{
					return RedirectToAction("Index", "Profile");
				}
			}
            else
            {
                user.Name = string.IsNullOrEmpty(p.Name) ? user.Name : p.Name;
                user.Surname = string.IsNullOrEmpty(p.Surname) ? user.Surname : p.Surname;
                user.Email = string.IsNullOrEmpty(p.Email) ? user.Email : p.Email;
                if (!string.IsNullOrEmpty(p.Password) && p.Password == p.PasswordConfirm)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
                }
                // TryValidateModel() ile modelin geçerliliğini kontrol ediyoruz.
                if (TryValidateModel(user))
                {
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Profile");
                    }
                }
            }
            return View();
		}
		[HttpPost]
		public async Task<IActionResult> DeleteAccountConfirmation()
		{
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (user != null)
			{
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
				{
                    /*var email = new MimeMessage();

                    email.From.Add(new MailboxAddress("Blog Project", ""));
                    email.To.Add(new MailboxAddress(user.Name + user.Surname, user.Email));

                    email.Subject = "Testing out email sending";
                    email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                    {
                        Text = "Hello all the way from the land of C#"
                    };
                    using (var smtp = new SmtpClient())
                    {
                        smtp.Connect("smtp.server.address", 587, false);

                        // Note: only needed if the SMTP server requires authentication
                        smtp.Authenticate("smtp_username", "smtp_password");

                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }*/
                    return RedirectToAction("Index", "LogOut");
                }
                else
                {
                    // Hesap silme işlemi başarısız oldu, hata mesajını görüntüleyebilirsiniz
                    ModelState.AddModelError("", "Hesap silme işlemi başarısız oldu.");
                }
            }
            else
            {
                // Kullanıcı bulunamadı, hata mesajını görüntüleyebilirsiniz
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
            }
            return View("Index");
        }
    }
}

