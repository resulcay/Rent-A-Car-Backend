using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> FetchAllCarImages();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> FetchCarImageById(int carImageId);

        IResult AddCarImage(CarImage carImage, IFormFile file);
        IResult UpdateCarImage(CarImage carImage, IFormFile file);
        IResult DeleteCarImage(CarImage carImage);
    }
}
