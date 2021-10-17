using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;

namespace ElectronicWallet.Services.Contracts
{
    public interface IOrderService: IManagementServiceBase<OrderDto, Order>
    {
    }
}
