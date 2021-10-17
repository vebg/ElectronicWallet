using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.Entities;

namespace ElectronicWallet.Database.EntitiesConfigurations.Profile
{
    public class AutoMapperDefaultProfile: AutoMapper.Profile
    {
        public AutoMapperDefaultProfile(): this("GlobalElectronicWallet")
        {

        }

        public AutoMapperDefaultProfile(string profileName) : base(profileName)
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<Wallet, WalletDto>().ReverseMap();
            CreateMap<WalletTransaction, WalletTransactionDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<UserWallet, UserWalletDto>().ReverseMap();
            CreateMap<Currency, CurrencyDto>().ReverseMap();

        }
    }
}
