using DatingApp.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.EF
{
    public partial class DatingAppDbContext : DbContext
    {
        public DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OnModelCreatingPartial(modelBuilder);

            modelBuilder.Seed();

            //modelBuilder.Entity<AppUser>().HasData(
            //    new AppUser
            //    {
            //        Id = 1,
            //        UserName = "Bob",
            //        PasswordHash = "",
            //        PasswordSalt = ""
            //    },
            //      new AppUser
            //      {
            //          Id = 2,
            //          UserName = "Tom",
            //          PasswordHash = "",
            //          PasswordSalt = ""
            //      }
            //    );
        }


        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
       

    }
}
