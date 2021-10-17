using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.DTO.Request;
using ElectronicWallet.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Api.Controllers.V1
{
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService userService;
        private new UserDto User => HttpContext.Items["User"] as UserDto;

        public AuthenticationController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost(ApiRoutes.Authentication.Login)]
        public async Task<ActionResult> Login([FromBody] LoginRequest login)
        {

            if (login is null)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "No data" }
                });
            }

            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "Email or password invalid." }
                });
            }

            var user = await userService.GetByEmailAndPassword(login.Email, login.Password);
            if(user == null)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "Email or password invalid." }
                });
            }

            //Create JWT

            //

            HttpContext.Items["User"] = user;
            return Ok(new ApiResponse<UserDto>(user));
        }

        [HttpPost(ApiRoutes.Authentication.LogOut)]
        public async Task<ActionResult> Logout()
        {
            User.TokenExpirationDate = null;
            User.AccessToken = null;

            var updated = await userService.UpdateAsync(User);
            if (!updated)
            {
                return BadRequest(new ApiResponse<UserDto>
                {
                    Succeeded = false,
                    Errors = new string[]
                    {
                        "Error closing trying to logout."
                    }
                });
            }

            return Ok(new ApiResponse<UserDto>
            {
                Succeeded = true
            });
        }
    }
}
