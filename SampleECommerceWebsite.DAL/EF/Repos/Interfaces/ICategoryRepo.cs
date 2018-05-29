﻿using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos.Interfaces
{
    public interface ICategoryRepo : IRepo<Category>
    {
        IEnumerable<Category> GetAllWithProducts();
        Category GetOneWithProducts(int id);
    }
}