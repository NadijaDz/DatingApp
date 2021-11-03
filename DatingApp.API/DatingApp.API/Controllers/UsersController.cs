using DatingApp.Database;
using DatingApp.DTOs;
using DatingApp.Infrastructure.EF;
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
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            return Ok(await _userService.GetUsersAsync());
        }

        [HttpGet("{username}")]

        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userService.GetMemberAsync(username);
        }


        [HttpPut]

        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //var username = User.FindFirst("NameId")?.Value;


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
            var user = await _userService.GetUserByUsernameAsync(username);

            _mapper.Map(memberUpdate, user);

            _userService.Update(user);

            if (await _userService.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
            return await _userService.UpdateUser(memberUpdateDto);
        }
    }
}
