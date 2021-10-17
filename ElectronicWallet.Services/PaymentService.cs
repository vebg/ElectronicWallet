using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class PaymentService : ManagementServiceBase<PaymentDto, Payment>, IPaymentService
    {
        public PaymentService(IPaymentRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
