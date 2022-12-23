using System;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            CreateAdminUserAndBaseRoles(modelBuilder);

            //modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        private void CreateAdminUserAndBaseRoles(ModelBuilder builder)
        {
            var guidUser = Guid.NewGuid().ToString();
            var guidAdminRole = Guid.NewGuid().ToString();
            var guidUserRole = Guid.NewGuid().ToString();

            var user = new User
            {
                Id = guidUser,
                FirstName = "Admin",
                LastName = "Adminych",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                LockoutEnabled = false,
            };

            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "123456");

            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = guidAdminRole,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = guidUserRole,
                    Name = "User",
                    NormalizedName = "USER",
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = guidAdminRole,
                    UserId = guidUser,
                });
        }
    }
}
