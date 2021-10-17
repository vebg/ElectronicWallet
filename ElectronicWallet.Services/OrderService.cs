﻿using AutoMapper;
using ElectronicWallet.Entities;
using ElectronicWallet.Entities.DTO;
using ElectronicWallet.Repositories.Contracts;
using ElectronicWallet.Services.Contracts;

namespace ElectronicWallet.Services
{
    public class OrderService : ManegementServiceBase<OrderDto, Order>, IOrderService
    {
        public OrderService(IOrderRepository repository,IMapper mapper):base(repository,mapper)
        {

        }
    }
}
