using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO.Request;
using ElectronicWallet.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Api.Controllers.V1
{
    public class UserWalletController : ControllerBase
    {
        private readonly IUserWalletService _userWalletService;
        private readonly IWalletService _walletService;


        public UserWalletController(IUserWalletService userWalletService, IWalletService walletService)
        {
            _userWalletService = userWalletService;
            _walletService = walletService;
        }


        [HttpGet(ApiRoutes.UsersWallets.Get)]
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

        [HttpGet(ApiRoutes.UsersWallets.GetBalance)]
        public async Task<ActionResult> GetBalance(Guid userId,Guid walletId)
        {
            try
            {
                return Ok(await _userWalletService.GetBalanceByUserIdAndWalletId(userId, walletId));
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

        [HttpPost(ApiRoutes.UsersWallets.AddBalance)]
        public async Task<ActionResult> AddBalance(Guid userId, Guid walletId, [FromBody] AddBalanceRequest balance)
        {
            try
            {
                if(balance is null)
                {
                    return BadRequest(new GenericResponse
                    {
                        Success = false,
                        Errors = new string[] { "balance could not be added." }
                    });
                }
                var userWallet = await _userWalletService.GetAsync(x => x.WalletId == walletId && x.UserId == userId);

                var wallatDto = userWallet.Wallet;

                wallatDto.Balance += balance.Amount;
                var response = await _walletService.UpdateAsync(wallatDto);

                if(response)
                {
                    return Ok(new GenericResponse());
                }

                return BadRequest(new GenericResponse(false,errors:new string[] { "balance could not be added." }) );
            }
            catch (Exception ex)
            {
                return BadRequest(new GenericResponse
                {
                    Success = false,
                    Errors = new string[] { "Error" }
                });
            }
        }
    }
}
