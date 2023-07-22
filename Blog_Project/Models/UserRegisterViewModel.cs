using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Blog_Project.Models
{
	public class UserRegisterViewModel
	{
        [Required(ErrorMessage = "Ad boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakterlik giriş yapmalısınız")]
        [MaxLength(13)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakterlik giriş yapmalısınız")]
        [MaxLength(13)]
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = "Resim boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar Şifre boş geçilemez")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu olmalı")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$", ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Mail { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Gizlilik Sözleşmesi kabul edilmeli")]
        public bool Privacy { get; set; }
    }
}

