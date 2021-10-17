using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class OrderService : ManagementServiceBase<OrderDto, Order>, IOrderService
    {
        public OrderService(IOrderRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
