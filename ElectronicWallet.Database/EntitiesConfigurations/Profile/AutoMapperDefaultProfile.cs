using ElectronicWallet.Common;
using ElectronicWallet.Database.DTO;
using ElectronicWallet.Database.DTO.Response;
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

            CreateMap<PagedResult<User>, PagedResult<UserDto>>().ReverseMap();
            CreateMap<PagedResult<Wallet>, PagedResult<WalletDto>>().ReverseMap();
            CreateMap<PagedResult<WalletTransaction>, PagedResult<WalletTransactionDto>>().ReverseMap();
            CreateMap<PagedResult<Order>, PagedResult<OrderDto>>().ReverseMap();
            CreateMap<PagedResult<Service>, PagedResult<ServiceDto>>().ReverseMap();
            CreateMap<PagedResult<Payment>, PagedResult<PaymentDto>>().ReverseMap();
            CreateMap<PagedResult<UserWallet>, PagedResult<UserWalletDto>> ().ReverseMap();
            CreateMap<PagedResult<Currency>, PagedResult<CurrencyDto>>().ReverseMap();

            CreateMap<UserDto, UserResponse>().ReverseMap();
        }
    }
}
