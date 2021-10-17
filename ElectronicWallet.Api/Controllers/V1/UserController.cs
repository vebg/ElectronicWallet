using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Services.Contracts;
using ElectronicWallet.Api.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ElectronicWallet.Database.DTO.Request;
using AutoMapper;
using ElectronicWallet.Database.DTO.Response;

namespace ElectronicWallet.Api.Controllers.V1
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<ActionResult> Get(Guid userId)
        {
            return Ok(new GenericResponse<UserDto>(await _userService.GetAsync(x => x.Id == userId)));
        }

        [HttpPost(ApiRoutes.Users.Create)]
        public async Task<ActionResult> Create([FromBody] UserCreateRequest request)
        {
            if (request is null)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "No data" }
                });
            }

            var userExist = await _userService.ExistAsync(x => x.Email == request.Email);

            if (userExist)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "User register." }
                });
            }

            try
            {
                var user = new UserDto()
                {
                    Gender = request.Gender.ToUpper(),
                    LastName = request.LastName,
                    Name = request.Name,
                    Email = request.Email,
                    //Password = request.Password
                };


                var userCreated = await _userService.CreateAsync(user);

                if (userCreated == null)
                {
                    return Ok(new GenericResponse<UserDto>()
                    {
                        Success = false,
                        Errors = new[] { "Error creating the user." }
                    });
                }
                return Ok(new GenericResponse<UserResponse>(_mapper.Map<UserResponse>(user)));

            }
            catch (Exception ex)
            {

                return BadRequest(new GenericResponse()
                {
                    Success = false,
                    Errors = new[] { ex.Message }
                });
            }

        }

        [Authorize]
        [HttpPut(ApiRoutes.Users.Update)]
        public async Task<ActionResult> Update(Guid userId, [FromBody] UserUpdateRequest request)
        {

            if (string.IsNullOrEmpty(userId.ToString()))
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "UserId Empty" }
                });
            }
            var userExist = await _userService.GetAsync(x => x.Id == userId);

            if (userExist == null)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "User not exist." }
                });
            }

            var user = new UserDto()
            {
                Id = userId,
                Gender = request.Gender,
                LastName = request.LastName,
                Name = request.Name,
                AccessToken = userExist.AccessToken,
                Email = request.Email,
                TokenExpirationDate = userExist.TokenExpirationDate
            };

            var updated = await _userService.UpdateAsync(user);

            if (updated)
            {
                return Ok(new GenericResponse<UserDto>
                {
                    Message = "User updated"
                });
            }

            return Ok(new GenericResponse<UserDto>
            {
                Success = false,
                Errors = new[] { "User not updated try again or contact the administration." }
            });
        }

        [Authorize]
        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<ActionResult> Delete(Guid userId)
        {

            var userExist = await _userService.ExistAsync(x => x.Id == userId);

            if (!userExist)
            {
                return BadRequest(new GenericResponse<UserDto>()
                {
                    Success = false,
                    Errors = new[] { "User not exist." }
                });
            }

            var user = await _userService.GetAsync(x => x.Id == userId);

            var deleted = await _userService.DeleteAsync(x => x.Id == userId);

            if (deleted)
            {
                return Ok(new GenericResponse<UserDto>
                {
                    Message = "User deleted"
                });
            }

            return BadRequest(new GenericResponse<UserDto>
            {
                Success = false,
                Errors = new[] { "User cannot be delete, please contact the administration." }
            });
        }
    }
}
