using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatingApp.Database
{
    public static class DatingAppDbContextData
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            using var hmac = new HMACSHA512();

            List<AppUser> users = new List<AppUser>()
            {
                new AppUser{Id=7,UserName="Dave",Gender="Male",
                    DateOfBirth=new DateTime(new Random().Next(2000, 2021), new Random().Next(1, 12), new Random().Next(1, 28),0,0,0),
                    KnownAs="Dave",
                    Created=DateTime.Now,
                    LastActive=DateTime.Now,
                    Introduction="test introduction",
                    LookingFor="test looking for",
                    Interests="Interests test",
                    City= "Byrnedale",
                    Country= "Dominican Republic",
                    PasswordHash =hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")).ToString(),
                    PasswordSalt=hmac.Key.ToString()},


                new AppUser{Id=8,UserName="Bob",Gender="Male",
                DateOfBirth=new DateTime(new Random().Next(2000, 2021), new Random().Next(1, 12), new Random().Next(1, 28),0,0,0),
                    KnownAs="Bob",
                    Created=DateTime.Now,
                    LastActive=DateTime.Now,
                    Introduction="test introduction",
                    LookingFor="test looking for",
                    Interests="Interests test",
                    City= "Thatcher",
                    Country= "S. Georgia and S. Sandwich Isls.",
                    PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")).ToString(),
                    PasswordSalt=hmac.Key.ToString()},
                
              
                new AppUser{Id=9,UserName="Rossa",Gender="Female",
                    DateOfBirth=new DateTime(new Random().Next(2000, 2021), new Random().Next(1, 12), new Random().Next(1, 28),0,0,0),
                    KnownAs="Rossa",
                    Created=DateTime.Now,
                    LastActive=DateTime.Now,
                    Introduction="test introduction",
                    LookingFor="test looking for",
                    Interests="Interests test",
                    City= "Mostar",
                    Country= "BiH",
                    PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")).ToString(),
                    PasswordSalt=hmac.Key.ToString()},
            };
            modelBuilder.Entity<AppUser>().HasData(users);


            List<Photo> photos = new List<Photo>()
            {
                new Photo{
                    Id=1,
                    Url= "https://randomuser.me/api/portraits/men/95.jpg",
                    AppUserId=7,
                    PublicId="11",
                    IsMain=true,
                },

                new Photo{
                    Id=2,
                    Url= "https://randomuser.me/api/portraits/men/97.jpg",
                    AppUserId=8,
                    PublicId="12",
                    IsMain=true,
                },

                  new Photo{
                    Id=3,
                    Url= "https://randomuser.me/api/portraits/women/6.jpg",
                    AppUserId=9,
                    PublicId="13",
                    IsMain=true
                },
            };
            modelBuilder.Entity<Photo>().HasData(photos);



            //var userData = System.IO.File.ReadAllText("UserSeedData.json");
            //var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            //foreach(var user in users)
            //{
            //    using var hmac = new HMACSHA512();
            //    user.UserName = user.UserName.ToLower();
            //    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")).ToString();
            //    user.PasswordSalt = hmac.Key.ToString();

            //    modelBuilder.Entity<AppUser>().HasData(user);
            //}
        }
        
    }
}
