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
    public class WalletController: ControllerBase
    {
        private readonly IWalletService _welletService;
        private readonly IUserService _userService;

        public WalletController(IWalletService welletService, IUserService userService)
        {
            _welletService = welletService;
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Wallets.Create)]
        public async Task<ActionResult> Create(Guid userId, [FromBody] WalletDto request)
        {
            try
            {
                var userExist = await _userService.ExistAsync(x => x.Id == userId);

                if(!userExist)
                {
                    return BadRequest(new GenericResponse
                    {
                        Success = false,
                        Errors = new string[] { "User not found." }
                    });
                }

                if (request is null)
                {
                    return BadRequest(new GenericResponse
                    {
                        Success = false,
                        Errors = new string[] { "Error try again." }
                    });
                }
                var response = await _welletService.CreateAndAssingWallet(userId, request);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse { 
                    Success = false,
                    Errors = new string [] { ex.Message }
                });
            }
        }
    }
}
