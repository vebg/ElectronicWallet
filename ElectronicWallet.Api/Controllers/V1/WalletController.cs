using ElectronicWallet.Api.Model.V1;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
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
    public class WalletController: ControllerBase
    {
        private readonly IWalletService _welletService;
        private readonly IUserService _userService;

        private const decimal DEFAULT_BALANCE = 500;

        public WalletController(IWalletService welletService, IUserService userService)
        {
            _welletService = welletService;
            _userService = userService;
        }

        [HttpPost(ApiRoutes.Wallets.Create)]
        public async Task<ActionResult> Create(Guid userId, [FromBody] WalletRequest request)
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

                var walletDto = new WalletDto
                {
                    Balance = DEFAULT_BALANCE, //default
                    Name = request.Name,
                    CurrencyId = request.CurrencyId
                };

                var response = await _welletService.CreateAndAssingWallet(userId, walletDto);
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

        [HttpPost(ApiRoutes.Wallets.AddBalance)]
        public async Task<ActionResult> AddBalance(Guid walletId, Guid userId, [FromBody] AddBalanceRequest balance)
        {
            try
            {
                if (balance is null)
                {
                    return BadRequest(new GenericResponse
                    {
                        Success = false,
                        Errors = new string[] { "balance could not be added." }
                    });
                }
                var userWallet = await _welletService.AddBalance(userId, walletId, balance.Amount);

                if (userWallet.Success)
                {
                    return Ok(new GenericResponse());
                }

                return BadRequest(new GenericResponse(false, errors: new string[] { "balance could not be added." }));
            }
            catch (Exception)
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
