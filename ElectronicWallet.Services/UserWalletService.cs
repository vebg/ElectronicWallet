using AutoMapper;
using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicWallet.Services
{
    public class UserWalletService: ManagementServiceBase<UserWalletDto, UserWallet>, IUserWalletService
    {
        IUserWalletRepository _userWalletRepository;
        IMapper _mapper;

        public UserWalletService(IUserWalletRepository repository,IMapper mapper):base(repository,mapper)
        {
            _userWalletRepository = repository;
            _mapper = mapper;
        }

        public async Task<GenericResponse<WalletDto>> GetWalletByUserIdAndWalletId(Guid userId, Guid walletId)
        {
            try
            {
                var userWallet = await _userWalletRepository.Query.Where(x => x.UserId == userId && x.WalletId == walletId).Include(s => s.Wallet).FirstOrDefaultAsync();

                if (userWallet is null)
                {
                    return new GenericResponse<WalletDto>(false, errors: new string[] { "User don't have wallet." });
                }

                var walletDto = _mapper.Map<WalletDto>(userWallet.Wallet);
                return new GenericResponse<WalletDto>(walletDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
                return new GenericResponse<WalletDto>(false, errors: new string[] { "Error." });
            }
        }

        public async Task<GenericResponse<List<WalletDto>>> GetWalletsByUserId(Guid userId)
        {
            try
            {
                var userWallets = await _userWalletRepository.Query.Where(x => x.UserId == userId).Include(s => s.Wallet).ToListAsync();

                if(userWallets is null || userWallets.Count == 0)
                {                   
                    return new GenericResponse<List<WalletDto>>(false, errors: new string[] { "User don't have wallets." });
                }

                var wallets = new List<WalletDto>();

                foreach (var item in userWallets)
                {
                    wallets.Add(Mapper.Map<WalletDto>(item.Wallet));
                }

                return new GenericResponse<List<WalletDto>>(wallets);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex}");
                return new GenericResponse<List<WalletDto>>(false, errors: new string[] { "Error." });
            }
        }
    }
}
