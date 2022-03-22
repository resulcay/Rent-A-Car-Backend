using Business.Abstract;
using Business.ValidationRules.FluentValiation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal brandDal;

        public BrandManager(IBrandDal ibrandDal)
        {
            brandDal = ibrandDal;
        }

        public IDataResult<List<Brand>> FetchAllBrands()
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorDataResult<List<Brand>>("Brands has not listed");
            }
            return new SuccessDataResult<List<Brand>>(brandDal.FetchAll(), "Brands has listed");
        }

        public IDataResult<Brand> FetchBrandById(int brandId)
        {
            if (DateTime.Now.Year == 1985)
            {
                return new ErrorDataResult<Brand>("Brand has not listed");
            }
            return new SuccessDataResult<Brand>(brandDal.Fetch(b => b.Id == brandId), "Brand has listed");
        }


        [ValidationAspect(typeof(BrandValidator))]

        public IResult AddBrand(Brand brand)
        {
            brandDal.Add(brand);

            return new SuccessResult("Brand has added");
        }

        public IResult UpdateBrand(Brand brand)
        {
            brandDal.Update(brand);

            return new SuccessResult("Brand has updated");
        }

        public IResult DeleteBrand(Brand brand)
        {
            brandDal.Delete(brand);

            return new SuccessResult("Brand has deleted");
        }

    }
}
