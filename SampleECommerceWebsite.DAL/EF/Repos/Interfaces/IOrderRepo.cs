﻿using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.Models.Entities;
using SampleECommerceWebsite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IEnumerable<Order> GetOrderHistory(int customerId);
        OrderWithDetailsAndProductInfo GetOneWithDetails(int customerId, int orderId);
    }
}
