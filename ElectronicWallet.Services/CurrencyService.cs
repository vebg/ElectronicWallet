using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class CurrencyService: ManegementServiceBase<CurrencyDto, Currency>, ICurrencyService
    {
        public CurrencyService(ICurrencyRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
