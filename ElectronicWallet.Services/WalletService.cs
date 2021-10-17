using AutoMapper;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public class WalletService: ManagementServiceBase<WalletDto, Wallet>, IWalletService
    {

        private readonly IUserWalletService _userWalletService;
        public WalletService(IWalletRepository repository,IMapper mapper, IUserWalletService userWalletService) :base(repository,mapper)
        {
            _userWalletService = userWalletService;
        }

        public async Task<GenericResponse> CreateAndAssingWallet(Guid userId, WalletDto request)
        {
            try
            {
                var entity = Mapper.Map<Wallet>(request);
                await Repository.CreateAsync(entity);
                await Repository.SaveChangesAsync();

                var userWallet = new UserWalletDto
                {
                    UserId = userId,
                    WalletId = request.Id
                };

                await _userWalletService.CreateAsync(userWallet);
                await Repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Creating the wallet: {ex}");
                return new GenericResponse(false,errors: new string[] { "Error Creating the wallet." });
            }

            return new GenericResponse();
        }
    }
}
