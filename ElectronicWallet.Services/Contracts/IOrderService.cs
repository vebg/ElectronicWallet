using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;

namespace ElectronicWallet.Services.Contracts
{
    public interface IOrderService: IManagementServiceBase<OrderDto, Order>
    {
    }
}
