using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.Models.Entities;
using SampleECommerceWebsite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos.Interfaces
{
    public interface IOrderDetailRepo : IRepo<OrderDetail>
    {
        IEnumerable<OrderDetailWithProductInfo> GetCustomersOrdersWithDetails(int customerId);
        IEnumerable<OrderDetailWithProductInfo> GetSingleOrderWithDetails(int orderId);
    }
}
