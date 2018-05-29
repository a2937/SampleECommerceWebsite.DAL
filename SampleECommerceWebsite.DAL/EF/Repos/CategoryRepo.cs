﻿using Microsoft.EntityFrameworkCore;
using SampleECommerceWebsite.DAL.EF.Repos.Base;
using SampleECommerceWebsite.DAL.EF.Repos.Interfaces;
using SampleECommerceWebsite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleECommerceWebsite.DAL.EF.Repos
{
    public class CategoryRepo : RepoBase<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public CategoryRepo()
        {
        }
        public override IEnumerable<Category> GetAll()
            => Table.OrderBy(x => x.CategoryName);

        public override IEnumerable<Category> GetRange(int skip, int take)
            => GetRange(Table.OrderBy(x => x.CategoryName), skip, take);

        public Category GetOneWithProducts(int id)
            => Table.Include(x => x.Products).FirstOrDefault(x => x.Id == id);

        public IEnumerable<Category> GetAllWithProducts()
            => Table.Include(x => x.Products);

    }
}
