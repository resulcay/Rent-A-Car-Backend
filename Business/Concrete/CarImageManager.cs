using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValiation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {

        ICarImageDal _carImageDal;
        IFileHelper _iFileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _iFileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> FetchAllCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.FetchAll(), "Car Images Fetched");
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageExist(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.FetchAll(ci => ci.CarId == carId));
        }

        public IDataResult<CarImage> FetchCarImageById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Fetch(c => c.Id == carImageId), "Car Image Fetched");
        }



        [ValidationAspect(typeof(CarImageValidator))]

        public IResult AddCarImage(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageCountExceed(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _iFileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult("CarImage has added");
        }

        public IResult UpdateCarImage(CarImage carImage, IFormFile file)
        {
            carImage.ImagePath = _iFileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult("CarImage has updated");
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            _iFileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("CarImage has deleted");
        }

        #region BusinessRules
        private IResult CheckIfCarImageCountExceed(int carId)
        {
            var result = _carImageDal.FetchAll(ci => ci.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExist(int carId)
        {
            var result = _carImageDal.FetchAll(ci => ci.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        #endregion




        // Default Car Image 
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();
            _carImageDal.Add(new CarImage { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}
