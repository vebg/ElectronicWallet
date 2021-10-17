using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class ServiceService : ManagementServiceBase<ServiceDto, Service>, IServiceService
    {
        public ServiceService(IServiceRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
