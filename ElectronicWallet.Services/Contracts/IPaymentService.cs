using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;

namespace ElectronicWallet.Services.Contracts
{
    public interface IPaymentService: IManagementServiceBase<PaymentDto, Payment>
    {
    }
}
