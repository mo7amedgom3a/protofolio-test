using Microsoft.AspNetCore.Mvc;
using UserManagementService.Interfaces;
using UserManagementService.Models;
using UserManagementService.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace UserManagementService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserProfileCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = _mapper.Map<User>(user);
            await _userService.CreateUserAsync(newUser);

            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserProfileUpdateDto updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.UpdateUserAsync(id, updatedUser);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost("{userId}/follow/{targetId}")]
        public async Task<IActionResult> FollowUser(string userId, string targetId)
        {
            var result = await _userService.FollowUserAsync(userId, targetId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost("{userId}/unfollow/{targetId}")]
        public async Task<IActionResult> UnfollowUser(string userId, string targetId)
        {
            var result = await _userService.UnfollowUserAsync(userId, targetId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("{userId}/followers")]
        public async Task<IActionResult> GetFollowers(string userId)
        {
            var followers = await _userService.GetFollowersAsync(userId);
            return Ok(followers);
        }
        [HttpGet("{userId}/following")]
        public async Task<IActionResult> GetFollowing(string userId)
        {
            var following = await _userService.GetFollowingAsync(userId);
            return Ok(following);
        }
    }
}
