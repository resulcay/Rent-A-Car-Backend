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
    public class CustomerManager : ICustomerService
    {

        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> FetchAllCustomers()
        {
            if (DateTime.Now.Year == 2000)
            {
                return new ErrorDataResult<List<Customer>>("Customers has not listed");
            }

            return new SuccessDataResult<List<Customer>>(_customerDal.FetchAll(), "Customers has listed");
        }

        public IDataResult<Customer> FetchCustomerById(int customerId)
        {
            if (DateTime.Now.Year == 1999)
            {
                return new ErrorDataResult<Customer>("Customer has not listed");
            }
            return new SuccessDataResult<Customer>(_customerDal.Fetch(cu => cu.Id == customerId), "Customer has listed");
        }


        [ValidationAspect(typeof(CustomerValidator))]

        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("Customer added");
        }

        public IResult UpdateCustomer(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult("Customer updated");
        }

        public IResult DeleteCustomer(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult("Customer deleted");
        }



    }
}
