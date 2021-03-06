﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsInfoContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.BrandId equals b.BrandId
                             join f in context.Colors on c.ColorId equals f.ColorId
                             select new CarDetailDto { CarId = c.CarId, BrandName = b.BrandName, ColorName=f.ColorName, DailyPrice=c.DailyPrice };
                return result.ToList();
            }
        }
    }
}
