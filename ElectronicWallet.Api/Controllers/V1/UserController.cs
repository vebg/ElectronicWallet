using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Api.Controllers.V1
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<ActionResult> GetAll(int? page, int? size)
        {
            return Ok(new ApiResponse<PagedResult<UserDto>>(await userService.GetAllAsync(page ?? 1, size ?? 10)));
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<ActionResult> Get(Guid userId)
        {
            return Ok(new ApiResponse<UserDto>(await userService.GetAsync(x => x.Id == userId)));
        }

        [HttpPost(ApiRoutes.Users.Create)]
        public async Task<ActionResult> Create([FromBody] UserDto user)
        {
            if (user is null)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "No data" }
                });
            }

            var userExist = await userService.ExistAsync(x => x.Email == user.Email);

            if (userExist)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "User register." }
                });
            }

            var userCreated = await userService.CreateAsync(user);

            if (userCreated == null)
            {
                return Ok(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "Error creating the user." }
                });
            }

            return Ok(new ApiResponse<UserDto>(user));
        }

        [HttpPut(ApiRoutes.Users.Update)]
        public async Task<ActionResult> Update(Guid userId, [FromBody] UserDto user)
        {
            if (user is null)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "No data" }
                });
            }

            var userExist = await userService.ExistAsync(x => x.Id == userId);

            if (!userExist)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "User not exist." }
                });
            }

            var updated = await userService.UpdateAsync(user);

            if (updated)
            {
                return Ok(new ApiResponse<UserDto>
                {
                    Message = "User updated"
                });
            }

            return Ok(new ApiResponse<UserDto> { 
                Succeeded = false,
                Errors = new[] { "User not updated try again or contact the administration." }
            });
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<ActionResult> Delete(Guid userId)
        {            

            var userExist = await userService.ExistAsync(x => x.Id == userId);

            if (!userExist)
            {
                return BadRequest(new ApiResponse<UserDto>()
                {
                    Succeeded = false,
                    Errors = new[] { "User not exist." }
                });
            }

            var user = await userService.GetAsync(x => x.Id == userId);

            var deleted = await userService.DeleteAsync(x => x.Id == userId);

            if (deleted)
            {
                return Ok(new ApiResponse<UserDto>
                {
                    Message = "User deleted"
                });
            }

            return BadRequest(new ApiResponse<UserDto>
            {
                Succeeded = false,
                Errors = new[] { "User cannot be delete, please contact the administration." }
            });
        }
    }
}
