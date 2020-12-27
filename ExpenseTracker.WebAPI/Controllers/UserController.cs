using AutoMapper;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using ExpenseTracker.WebAPI.UtilModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("register", Name = "register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ApplicationUser>(model);
                var registrationResult = await _userManager.CreateAsync(user, model.Password);
                if (registrationResult.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDTO>(user);
                    return Created("register", new ResponseModel(201, "User Was successfully registered", userToReturn));
                }
                var error = registrationResult.Errors;
                return BadRequest(new ResponseModel(400, "Registration Failed", error));
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "There are some validation Errors", errors));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserToLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    var roles = (await _userManager.GetRolesAsync(user)).ToList();
                    var token = TokenConfiguration.GenerateToken(user, _config, roles);
                    return Ok(new ResponseModel(200, "User Was successfully Logged in", new { token }));
                }
                return BadRequest(new ResponseModel(400, "Login Failed", signInResult));
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "There are some validation Errors", errors));
        }

        [HttpPatch]
        [Route("edit")]
        public async Task<IActionResult> EditProfile([FromBody] UserDTO userToUpdate)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ApplicationUser>(userToUpdate);
                var userToReturn = _mapper.Map<UserDTO>(user);
                var updateResult = await _userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {

                    return Ok(new ResponseModel(200, "Profile sucessfully updated", userToReturn));
                }
                return BadRequest(new ResponseModel(400, "Update Failed", userToReturn));
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel(400, "There are some validation Errors", errors));
        }

        [HttpPost]
        [Route("profilePicture")]
        [Authorize]
        public async Task<IActionResult> UpdateProfilePicture([FromBody] PhotoToUpdateDTO photoToUpdate)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            user.PhotoPublicId = photoToUpdate.PhotoPublicId;
            user.PhotoUrl = photoToUpdate.PhotoUrl;
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                var userToReturn = _mapper.Map<UserDTO>(user);
                return Ok(new ResponseModel(200, "Success", userToReturn));
            }
            return BadRequest(new ResponseModel(400, "Update failed", photoToUpdate));
        }

        [HttpPatch]
        [Route("profilePicture")]
        [Authorize]
        public async Task<IActionResult> DeleteProfilePicture()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            var userToReturn = _mapper.Map<UserDTO>(user);
            if (user == null)
            {
                return BadRequest(new ResponseModel(400, "User does not exist", userToReturn));
            }
            user.PhotoUrl = null;
            user.PhotoPublicId = null;
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                return Ok(new ResponseModel(200, "Success", userToReturn));
            }
            return BadRequest(new ResponseModel(400, "Update failed", userToReturn));
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
