using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length==2)
            {
                return new ErrorResult(Messages.NameInvailed);

            }

            _brandDal.Add(brand);

            return new SuccessResult(Messages.Added);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour==19)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }
    }
}
