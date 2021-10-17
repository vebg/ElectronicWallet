using ElectronicWallet.Common.Options;
using ElectronicWallet.Infraestructure.Enums;
using ElectronicWallet.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicWallet.Infraestructure.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtOptions _jwtOptions;

        public JwtMiddleware(RequestDelegate next, IOptions<JwtOptions> JwtOptions)
        {
            _next = next;
            _jwtOptions = JwtOptions.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();

            if (token != null)
                await AttachUserToContextAsync(context, token, userService);

            await _next(context);
        }

        private async Task AttachUserToContextAsync(HttpContext context, string token, IUserService userService)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtOptions.Key);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ValidAudiences = Enum.GetNames(typeof(UserType)),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;
                var id = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                UserType userType = (UserType)Enum.Parse(typeof(UserType), jwtToken.Audiences.First());

                // attach user to context on successful jwt validation
                var user = await userService.GetAsync(x => x.Id == id);

                if (!user.AccessToken.Equals(token))
                    throw new ArgumentException($"Invalid token. User = {id}, Token = {token}", "Access Token");

                context.Items["User"] = user;
            }
            catch (Exception)
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes

                //_logger.LogError("Error in authentication process. Ex: {ex}", ex);
            }
        }
    }

}
