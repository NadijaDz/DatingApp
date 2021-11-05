using AutoMapper;
using DatingApp.Database;
using DatingApp.DTOs;
using DatingApp.Infrastructure.EF;
using DatingApp.Infrastructure.Extensions;
using DatingApp.Infrastructure.Helpers;
using DatingApp.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        protected readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IPhotoService _photoservice;

        public UsersController(IUserService userService, IMapper mapper, IPhotoService photoservice)
        {
            _userService = userService;
            _mapper = mapper;
            _photoservice = photoservice;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var user = await _userService.GetUserByUsernameAsync(User.GetUsername());
            userParams.CurrentUsername = user.UserName;
            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = user.Gender == "male" ? "female" : "male";
            }

           var users = await _userService.GetMembersAsync(userParams);
            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);

            return Ok(users);
        }

        [HttpGet("{username}", Name = "GetUser")]

        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userService.GetMemberAsync(username);
        }


        [HttpPut]

        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {


            //var username = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //var username = User.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

            //var username = "bob";

            //var claimsIdentity = User.Identity as ClaimsIdentity;
            //var username= claimsIdentity.FindFirst("nameid");

            //foreach (var claim in claimsIdentity.Claims)
            //{
            //    System.Console.WriteLine(claim.Type + ":" + claim.Value);
            //}


            //var username = memberUpdate.Username;
            var user = await _userService.GetUserByUsernameAsync(User.GetUsername());

            _mapper.Map(memberUpdateDto, user);

            _userService.Update(user);

            if (await _userService.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
            //return await _userService.UpdateUser(memberUpdateDto);
        }


        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto(IFormFile file)
        {
            var user = await _userService.GetUserByUsernameAsync(User.GetUsername());
            var result = await _photoservice.AddPhotoAsync(file);

            if (result.Error != null)
            {
                return BadRequest(result.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Photos.Count == 0)
            {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);
            if (await _userService.SaveAllAsync())
            {
                return CreatedAtRoute("GetUser", new { username = user.UserName }, _mapper.Map<PhotoDto>(photo));
            }

            return BadRequest("Problem adding photo");
        }


        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await _userService.GetUserByUsernameAsync(User.GetUsername());
            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo.IsMain) return BadRequest("This is already your main photo");

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;

            if (await _userService.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await _userService.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
            {
                return NotFound();
            }

            if (photo.IsMain)
            {
                return BadRequest("You cannont delete main photo");

            }

            if (photo.PublicId != null)
            {
                var result = await _photoservice.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null)
                {
                    return BadRequest(result.Error.Message);
                }
            }

            user.Photos.Remove(photo);
            if (await _userService.SaveAllAsync())
            {
                return Ok();
            }

            return BadRequest("Failed to delete photo");
        }

    }
}
