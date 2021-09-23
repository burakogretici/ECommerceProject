﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EticaretContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (EticaretContext context = new EticaretContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join brand in context.Brands on p.BrandId equals brand.Id
                             select new ProductDetailDto
                             {
                                 ProductName = p.Name,
                                 CategoryName = c.Name,
                                 BrandName = brand.Name,
                                 UnitPrice = p.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}