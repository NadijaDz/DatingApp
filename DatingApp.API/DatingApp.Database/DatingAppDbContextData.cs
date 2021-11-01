using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Database
{
    public static class DatingAppDbContextData
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<AppUser> users = new List<AppUser>()
            {
                new AppUser{Id=1,UserName="Dave",PasswordHash="cGFzc3dvcmQ=ZGF0aW5nYXBw",PasswordSalt="ZGF0aW5nYXBw"},
                new AppUser{Id=2,UserName="Bob",PasswordHash="cGFzc3dvcmQ=ZGF0aW5nYXBw",PasswordSalt="ZGF0aW5nYXBw"},
                new AppUser{Id=3,UserName="Tom",PasswordHash="cGFzc3dvcmQ=ZGF0aW5nYXBw",PasswordSalt="ZGF0aW5nYXBw"},
            };
            modelBuilder.Entity<AppUser>().HasData(users);
        }
        
    }
}
