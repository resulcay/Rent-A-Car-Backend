using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValiation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        [CacheAspect]
        public IDataResult<List<Car>> FetchAllCars()
        {
            if (DateTime.Now.Year == 2000)
            {
                return new ErrorDataResult<List<Car>>(Messages.WhileFetching);
            }

            return new SuccessDataResult<List<Car>>(_iCarDal.FetchAll(), Messages.CarsListed);
        }

        public IDataResult<Car> FetchCarByBrandId(int id)

        {
            if (DateTime.Now.Year == 1998)
            {
                return new ErrorDataResult<Car>(Messages.WhileFetching);
            }

            return new SuccessDataResult<Car>(_iCarDal.Fetch(p => p.BrandId == id), Messages.CarsListed);

        }

        public IDataResult<List<Car>> FetchCarByDailyPrice(int min, int max)
        {
            if (DateTime.Now.Year == 1957)
            {
                return new ErrorDataResult<List<Car>>(Messages.WhileFetching);
            }

            return new SuccessDataResult<List<Car>>(_iCarDal.FetchAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<CarDetailDto>> FetchCarDetails()
        {
            if (DateTime.Now.Year == 2010)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.WhileFetching);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(), Messages.CarsListed);
        }


        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Fetch")]

        public IResult AddCar(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarDescriptionExists(car.Description), CheckIfCarTooOld(car.ModelYear));

            _iCarDal.Add(car);

            return new SuccessResult("Car has added");
        }


        [CacheRemoveAspect("ICarService.Fetch")]

        public IResult UpdateCar(Car car)
        {
            _iCarDal.Update(car);

            return new SuccessResult("Car has updated");
        }

        public IResult DeleteCar(Car car)
        {
            _iCarDal.Delete(car);

            return new SuccessResult("Car has deleted");
        }

        #region BusinessRules


        private IResult CheckIfCarDescriptionExists(string description)
        {
            var result = _iCarDal.FetchAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult("Operation Failed");
            }
            return new SuccessResult("Operation Succesful");
        }

        private IResult CheckIfCarTooOld(int modelYear)
        {
            var result = _iCarDal.FetchAll(c => c.ModelYear <= modelYear).Any();
            if (result)
            {
                return new ErrorResult("Operation Failed");
            }
            return new SuccessResult("Operation Succesful");
        }

        #endregion
    }
}
