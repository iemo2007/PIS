using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PIS.Application;
using PIS.DAL;
using PIS.DTO;
using PIS.DTO.Responses;
using PIS.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JWTService jwtService,
            IUnitOfWork unitOfWork)
        {
            this._userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            ResponseDTO response = new ResponseDTO();
            ApplicationUser user = await _userManager.FindByEmailAsync(registerDTO.Email.ToLower());
            
            station station = _unitOfWork.stations.GetAll().FirstOrDefault(tt => tt.StationCode.Trim() == registerDTO.StationNo.Trim());
            if(station == null) 
            {
                response.ErrorMessage = "There is no station with such code";
                response.IsSuccess = false;
                return BadRequest(response);
            }

            if (user != null)
            {
                response.ErrorMessage = "There is another active account with the same email";
                response.IsSuccess = false;
                return BadRequest(response);
            }

            ApplicationUser newUser = new ApplicationUser
            {
                StationNo = registerDTO.StationNo,
                Email = registerDTO.Email.ToLower(),
                UserName = registerDTO.Email.ToLower(),

                EmailConfirmed = true
            };

            IdentityResult registerRresult = await _userManager.CreateAsync(newUser, registerDTO.Password);

            if (!registerRresult.Succeeded)
            {
                response.ErrorMessage = registerRresult.Errors.FirstOrDefault().Description;
                response.IsSuccess = false;
                return BadRequest(response);
            }
            APIResponse successResponse = new APIResponse(200, "Registered successfully");
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            ResponseDTO response = new ResponseDTO { IsSuccess = false };

            ApplicationUser user = await _userManager.FindByNameAsync(loginDTO.Username.ToLower());


            if (user == null)
            {
                response.ErrorMessage = "Username or password is incorrect";
                return Unauthorized(response);
            }

            if (!user.EmailConfirmed)
            {
                response.ErrorMessage = "You need to confirm your E-mail first before login";
                return Unauthorized(response);
            }

            Microsoft.AspNetCore.Identity.SignInResult signInResult =
                await _signInManager.PasswordSignInAsync(user, loginDTO.Password, true, false);

            if (!signInResult.Succeeded)
            {
                response.ErrorMessage = "Username or password is incorrect";
                return Unauthorized(response);
            }

            string userToken = _jwtService.CreateJWT(user);

            UserDTO loggedInUser = new UserDTO { Username = user.UserName, Token = userToken };
            response.IsSuccess = true;
            return Ok(loggedInUser);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserData()
        {
            List<ApplicationUser> users = _userManager.Users.ToList();
            return Ok(users);
        }

        // PUT: api/users/{id}
        [HttpPut()]
        // [Authorize(Roles = "Admin")] // Only admin can access this endpoint
        public async Task<IActionResult> UpdateUserData(UserData userData)
        {
            ResponseDTO response = new ResponseDTO { IsSuccess = false };
            ApplicationUser user = await _userManager.FindByNameAsync(userData.Email);

            if (user == null)
            {
                response.ErrorMessage = "No user with such Username";
                return NotFound(response);
            }

            user.StationNo = userData.StationNo;
            // Update other properties as needed

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                response.ErrorMessage = "No user with such Username";
                return BadRequest(response);
            }

            response.IsSuccess = true;
            return Ok(user);
        }
    }
}
