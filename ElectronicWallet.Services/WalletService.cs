using AutoMapper;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public class WalletService: ManagementServiceBase<WalletDto, Wallet>, IWalletService
    {

        private readonly IUserWalletService _userWalletService;
        private readonly IWalletService _walletService;

        private readonly IUserWalletRepository _userWalletRepository;
        private readonly IMapper _mapper;


        public WalletService(IWalletRepository repository,IMapper mapper, IUserWalletService userWalletService, IUserWalletRepository userWalletRepository) :base(repository,mapper)
        {
            _userWalletService = userWalletService;
            _userWalletRepository = userWalletRepository;
            _mapper = mapper;
        }

        public async Task<GenericResponse> AddBalance(Guid userId, Guid walletId, decimal amount)
        {
            try
            {
                var userWallet = await _userWalletRepository.Query.Where(x => x.UserId == userId && x.WalletId == walletId).Include(s => s.Wallet).FirstOrDefaultAsync();

                if (userWallet is null)
                {
                    return new GenericResponse(false, errors: new string[] { "User don't have wallet." });
                }

                userWallet.Wallet.Balance += amount;
                await Repository.CreateAsync(userWallet.Wallet);
                await Repository.SaveChangesAsync();
                return new GenericResponse(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
                return new GenericResponse(false, errors: new string[] { "Error." });
            }
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
                    WalletId = entity.Id
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
