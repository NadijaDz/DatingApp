using DatingApp.Database;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.EF
{
    public class DatingAppDbContext : IdentityDbContext<AppUser, AppRole, int,
        Microsoft.AspNetCore.Identity.IdentityUserClaim<int>, AppUserRole, 
        Microsoft.AspNetCore.Identity.IdentityUserLogin<int>, IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : base(options)
        {
        }

       
        public DbSet<Photo> Photos { get; set; }

        public DbSet<UserLike> Likes{get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>()
                 .HasMany(ur => ur.UserRoles)
                 .WithOne(u => u.User)
                 .HasForeignKey(ur => ur.UserId)
                 .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();


            modelBuilder.Entity<UserLike>().HasKey(k => new { k.SourceUserId, k.LikedUserId });

            modelBuilder.Entity<UserLike>().HasOne(s => s.SourceUser).WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.NoAction); // when delete user delete related entity


            modelBuilder.Entity<UserLike>().HasOne(s => s.LikedUser).WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.LikedUserId)
                .OnDelete(DeleteBehavior.NoAction); // when delete user delete related entity
        }     

    }
}
