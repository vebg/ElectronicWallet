using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO.Request;
using ElectronicWallet.Services.Contracts;
using ElectronicWallet.Api.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class UserWalletController : ControllerBase
    {
        private readonly IUserWalletService _userWalletService;

        public UserWalletController(IUserWalletService userWalletService)
        {
            _userWalletService = userWalletService;
        }

        [HttpGet(ApiRoutes.UsersWallets.GetAll)]
        public async Task<ActionResult> GetUserWalletsByUserId(Guid userId)
        {
            try
            {                
                return Ok(await _userWalletService.GetWalletsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse
                {
                    Success = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }

        [HttpGet(ApiRoutes.UsersWallets.Get)]
        public async Task<ActionResult> GetBalance(Guid userId,Guid walletId)
        {
            try
            {
                return Ok(await _userWalletService.GetWalletByUserIdAndWalletId(userId, walletId));
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse
                {
                    Success = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }
    
    }
}
