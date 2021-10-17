using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using System.Threading.Tasks;

namespace ElectronicWallet.Services.Contracts
{
    public interface IUserService: IManagementServiceBase<UserDto,User>
    {
        public Task<UserDto> GetByEmailAndPassword(string email, string password);
    }
}
