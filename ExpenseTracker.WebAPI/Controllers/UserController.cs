using AutoMapper;
using ExpenseTracker.WebAPI.DTOs;
using ExpenseTracker.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register", Name = "register")]
        public async Task<IActionResult> RegisterUser(UserToRegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ApplicationUser>(model);
                var registrationResult = await _userManager.CreateAsync(user);
                if (registrationResult.Succeeded)
                {
                    return Created("register", new ResponseModel 
                    { 
                        Status = 201,
                        Description = "User Was successfully registered",
                        Data = user
                    });
                }
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Description = "Registration Failed",
                    Data = user
                });
            }
            return BadRequest(new ResponseModel
            {
                Status = 400,
                Description = "There are some validation Errors",
                Data = model
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserToLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return Ok(new ResponseModel
                    {
                        Status = 200,
                        Description = "User Was successfully Logged in",
                        Data = signInResult
                    });
                }
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Description = "Login Failed",
                    Data = signInResult
                });
            }
            else
            {
               var errors = ModelState.Values.Select(model => model.Errors).ToList();
                return BadRequest(new ResponseModel
                {
                    Status = 400,
                    Description = "There are some validation Errors",
                    Data = errors
                });
            }
        }
    }
}
