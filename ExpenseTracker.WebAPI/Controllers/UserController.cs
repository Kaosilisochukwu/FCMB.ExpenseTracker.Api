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
                    return Created("register", new ResponseModel 
                    { 
                        Status = 201,
                        Message = "User Was successfully registered",
                        Data = userToReturn
                    });
                }
                var error = registrationResult.Errors;
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Message = "Registration Failed",
                    Data = error
                });
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Message = "There are some validation Errors",
                Data = errors
            });
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
                    return Ok(new ResponseModel
                    {
                        Status = 200,
                        Message = "User Was successfully Logged in",
                        Data = new { token }
                    });
                }
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Message = "Login Failed",
                    Data = signInResult
                });
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Message = "There are some validation Errors",
                Data = errors
            });
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

                    return Ok(new ResponseModel
                    {
                        Status = 200,
                        Message = "Profile sucessfully updated",
                        Data = userToReturn
                    });
                }
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Message = "Update Failed",
                    Data = userToReturn
                });
            }
            var errors = ModelState.Values.Select(model => model.Errors).ToList();
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Message = "There are some validation Errors",
                Data = errors
            });
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
                return Ok(new ResponseModel
                {
                    Status = 200,
                    Message = "Success",
                    Data = userToReturn
                });
            }
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Message = "Update failed",
                Data = photoToUpdate
            });
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
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Message = "User does not exist",
                    Data = userToReturn
                });
            }
            user.PhotoUrl = null;
            user.PhotoPublicId = null;
            var updateResult = await _userManager.UpdateAsync(user);
            if (updateResult.Succeeded)
            {
                return Ok(new ResponseModel
                {
                    Status = 200,
                    Message = "Success",
                    Data = userToReturn
                });
            }
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Message = "Update failed",
                Data = userToReturn
            });
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
