using AutoMapper;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class CurrencyService: ManagementServiceBase<CurrencyDto, Currency>, ICurrencyService
    {
        public CurrencyService(ICurrencyRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
