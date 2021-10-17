using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class ServiceService : ManegementServiceBase<ServiceDto, Service>, IServiceService
    {
        public ServiceService(IServiceRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
