using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.DTOs.CarDetailDto;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> FetchAllCars();
        IDataResult<Car> FetchCarByBrandId(int id);
        IDataResult<List<Car>> FetchCarByDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> FetchCarDetails();
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
    }
}
