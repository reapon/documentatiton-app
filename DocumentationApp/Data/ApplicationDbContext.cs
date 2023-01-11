using DocumentationApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DocumentationApp.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace DocumentationApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Content> Contents { get; set; }

        public DbSet<App> Apps { get; set; }

        public DbSet<MarkAsRead> MarkAsReads { get; set; }

        public DbSet<SearchByUser> SearchByUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seeding a  'Administrator' role to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2c5e174e-3b0e-421f-86af-483d56fd7210", Name = "Super Admin", NormalizedName = "Super Admin".ToUpper() });


            //a hasher to hash the password before seeding the user to the db
            var hasher = new PasswordHasher<IdentityUser>();


            //Seeding the User to AspNetUsers table
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "reapon@gmail.com",
                    NormalizedUserName = "reapon@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Reapon@123"),
                    EmailConfirmed = true
                }
            );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9550d048cdb9", // primary key
                    UserName = "gtradmin@gmail.com",
                    NormalizedUserName = "gtradmin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Gtradmin@123"),
                    EmailConfirmed = true
                }
            );


            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-421f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9550d048cdb9"
                }
            );


        }


    }
}
