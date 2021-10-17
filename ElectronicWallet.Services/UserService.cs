using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class UserService: ManegementServiceBase<UserDto,User>,IUserService
    {
        public UserService(IUserRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
