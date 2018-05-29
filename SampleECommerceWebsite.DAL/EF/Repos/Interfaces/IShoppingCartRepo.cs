using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.Models.Entities;
using SampleECommerceWebsite.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos.Interfaces
{
    public interface IShoppingCartRepo : IRepo<ShoppingCartRecord>
    {
        CartRecordWithProductInfo GetShoppingCartRecord(int customerId, int productId);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        int Purchase(int customerId);
        ShoppingCartRecord Find(int customerId, int productId);
        int Update(ShoppingCartRecord entity, int? quantityInStock, bool persist = true);
        int Add(ShoppingCartRecord entity, int? quantityInStock, bool persist = true);
    }
}
