﻿using Microsoft.EntityFrameworkCore;
using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.DAL.EF.Repos.Interfaces;
using SampleECommerceWebsite.Models.Entities;
using SampleECommerceWebsite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos
{
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        public OrderRepo(DbContextOptions<StoreContext> options, IOrderDetailRepo orderDetailRepo) : base(options)
        {
            _orderDetailRepo = orderDetailRepo;
        }
        public OrderRepo(IOrderDetailRepo orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        public override IEnumerable<Order> GetAll()
            => Table.OrderByDescending(x => x.OrderDate);

        public override IEnumerable<Order> GetRange(int skip, int take)
            => GetRange(Table.OrderByDescending(x => x.OrderDate), skip, take);

        public IEnumerable<Order> GetOrderHistory(int customerId)
            => Table.Where(x => x.CustomerId == customerId)
                    .Select(x => new Order
                    {
                        Id = x.Id,
                        TimeStamp = x.TimeStamp,
                        CustomerId = customerId,
                        OrderDate = x.OrderDate,
                        OrderTotal = x.OrderTotal,
                        ShipDate = x.ShipDate,
                    });

        public OrderWithDetailsAndProductInfo GetOneWithDetails(int customerId, int orderId)
            => Table
                .Where(x => x.CustomerId == customerId && x.Id == orderId)
                .Select(x => new OrderWithDetailsAndProductInfo
                {
                    Id = x.Id,
                    CustomerId = customerId,
                    OrderDate = x.OrderDate,
                    OrderTotal = x.OrderTotal,
                    ShipDate = x.ShipDate,
                    OrderDetails = _orderDetailRepo.GetSingleOrderWithDetails(orderId).ToList()
                })
            .FirstOrDefault();
    }
}
