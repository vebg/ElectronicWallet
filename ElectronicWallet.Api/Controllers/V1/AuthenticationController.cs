using ElectronicWallet.Api.CustomAttributes;
using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Common.Options;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.DTO.Request;
using ElectronicWallet.Infraestructure.Enums;
using ElectronicWallet.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWallet.Api.Controllers.V1
{
    [ApiController]
    public class AuthenticationController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtOptions _jwtOptions;

        private new UserDto User => HttpContext.Items["User"] as UserDto;

        public AuthenticationController(IUserService userService, IOptions<JwtOptions> jwtOptions)
        {
            _userService = userService;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost(ApiRoutes.Authentication.Login)]
        public async Task<ActionResult> Login([FromBody] LoginRequest login)
        {

            if (login is null)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "No data" }
                });
            }

            if (string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "Email or password invalid." }
                });
            }

            var user = await _userService.GetByEmailAndPassword(login.Email, login.Password);
            if(user == null)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "Email or password invalid." }
                });
            }
            //Create JWT
            user = CreateJwt(user);

            if (string.IsNullOrEmpty(user.AccessToken))
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "Error creating the token." }
                });
            }

            HttpContext.Items["User"] = user;

            var updated = await _userService.UpdateAsync(user);

            if(updated)
            {
                return Ok(new GenericResponse<UserDto>(user));
            }

            return BadRequest(new GenericResponse(false,errors: new string[] { "Login error, contact the admin." }) );
        }

        [Authorize]
        [HttpPost(ApiRoutes.Authentication.LogOut)]
        public async Task<ActionResult> Logout()
        {
            User.TokenExpirationDate = null;
            User.AccessToken = null;

            var updated = await _userService.UpdateAsync(User);
            if (!updated)
            {
                return BadRequest(new GenericResponse<UserDto>
                {
                    Success = false,
                    Errors = new string[]
                    {
                        "Error closing trying to logout."
                    }
                });
            }

            return Ok(new GenericResponse<UserDto>
            {
                Success = true
            });
        }

        private UserDto CreateJwt(UserDto user)
        {
            try
            {
                var now = DateTimeOffset.Now.DateTime;
                user.TokenExpirationDate = now.AddDays(1);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("last_name", user.LastName),
                new Claim("email", user.Email)
            };

                if (user.Gender != null) claims.Add(new Claim("gender", user.Gender.ToString()));

                var jwtSecurityToken = new JwtSecurityToken(
                    audience: Enum.GetName(typeof(UserType), UserType.User),
                    claims: claims,
                    notBefore: now,
                    expires: user.TokenExpirationDate,
                    signingCredentials: signingCredentials
                );

                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

                user.AccessToken = token;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating token. User Id = {id} Exception = {ex}", user?.Id, ex);
            }

            return user;
        }

    }
}
