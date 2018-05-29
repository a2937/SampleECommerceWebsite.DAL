using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.Models.Entities;
using SampleECommerceWebsite.Models.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos.Interfaces
{
    public interface IProductRepo : IRepo<Product>
    {
        IEnumerable<ProductAndCategoryBase> Search(string searchString);
        IEnumerable<ProductAndCategoryBase> GetAllWithCategoryName();
        IEnumerable<ProductAndCategoryBase> GetProductsForCategory(int id);
        IEnumerable<ProductAndCategoryBase> GetFeaturedWithCategoryName();
        ProductAndCategoryBase GetOneWithCategoryName(int id);
    }
}
