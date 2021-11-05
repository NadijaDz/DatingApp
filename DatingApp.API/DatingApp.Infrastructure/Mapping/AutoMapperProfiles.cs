using AutoMapper;
using DatingApp.Database;
using DatingApp.DTOs;
using DatingApp.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatingApp.Infrastructure.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest=>dest.PhotoUrl, opt=>opt.MapFrom(src=>
                  src.Photos.FirstOrDefault(x=>x.IsMain).Url))
                .ForMember(dest=>dest.Age, opt=>opt.MapFrom(src=>src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<AppUser, MemberUpdateDto>().ReverseMap();
            CreateMap<RegisterDto, AppUser>();


        }
    }
}
