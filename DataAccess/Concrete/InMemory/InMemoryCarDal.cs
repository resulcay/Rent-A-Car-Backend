using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
            new Car() { Id = 1, BrandId = 2, ColorId = 3, DailyPrice = 4, Description = "some desc", ModelYear = 9000 },
            new Car() { Id = 5, BrandId = 6, ColorId = 7, DailyPrice = 8, Description = "soav dbvc", ModelYear = 7000 },
            new Car() { Id = 9, BrandId = 1, ColorId = 5, DailyPrice = 2, Description = "lkon cawf", ModelYear = 5000 },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public Car Fetch(Expression<Func<Car, bool>> filter)
        {
            return null;
        }

        public List<Car> FetchAll()
        {
            return _cars;
        }

        public List<Car> FetchAll(Expression<Func<Car, bool>> filter = null)
        {
            return null;
        }

        public List<Car> FetchAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return null;
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
