using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;

namespace ElectronicWallet.Services.Contracts
{
    public interface IUserService: IManagementServiceBase<UserDto,User>
    {
    }
}
