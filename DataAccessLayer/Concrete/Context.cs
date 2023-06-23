using System;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AdminUser, AdminUserRole, int> // DbContext Miras alındı
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=BlogProjectDB;User=SA; Password=reallyStrongPwd123"); // bağlantıyı tutan yapı
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Awards> Awards { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
    }
}

