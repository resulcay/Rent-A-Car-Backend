using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValiation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal iuserDal)
        {
            _userDal = iuserDal;
        }


        public IDataResult<List<User>> FetchAllUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.FetchAll(), Messages.Succesfull);
        }

        public IDataResult<User> FetchUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Fetch(u => u.Id == userId), Messages.Succesfull);
        }


        [ValidationAspect(typeof(UserValidator))]

        public IResult AddUser(User user)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("User has not added");
            }
            _userDal.Add(user);
            return new SuccessResult("User has added");
        }

        public IResult UpdateUser(User user)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("User has not updated");
            }
            return new SuccessResult("User has updated");
        }

        public IResult DeleteUser(User user)
        {
            if (DateTime.Now.Year == 1950)
            {
                return new ErrorResult("User has not deleted");
            }
            return new SuccessResult("User has deleted");
        }

        public List<OperationClaim> GetClaims(User user)
        {

            return _userDal.GetClaims(user);
        }

        public User GetByMail(string email)
        {

            return _userDal.Fetch(u => u.Email == email);
        }
    }
}
