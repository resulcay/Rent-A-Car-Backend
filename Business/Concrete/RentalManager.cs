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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> FetchAllRentals()
        {
            if (DateTime.Now.Year == 1453)
            {
                return new ErrorDataResult<List<Rental>>("Rentals has not listed");
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.FetchAll(), "Rentals has listed");
        }

        public IDataResult<Rental> FetchRentalById(int rentalId)
        {
            if (DateTime.Now.Year == 1450)
            {
                return new ErrorDataResult<Rental>("Rental has not listed");
            }
            return new SuccessDataResult<Rental>(_rentalDal.Fetch(r => r.Id == rentalId), "Rental has listed");
        }


        [ValidationAspect(typeof(RentalValidator))]

        public IResult AddRental(Rental rental)
        {
            _rentalDal.Add(rental);

            return new SuccessResult("Rental added");

        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);

            return new SuccessResult("Rental updated");
        }

        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);

            return new SuccessResult("Rental deleted");
        }

    }
}
