using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> FetchAllUsers();

        IDataResult<User> FetchUserById(int userId);

        List<OperationClaim> GetClaims(User user);

        User GetByMail(string email);

        IResult AddUser(User user);
        IResult UpdateUser(User user);
        IResult DeleteUser(User user);
    }
}
