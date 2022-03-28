using Journal.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Journal.Repository.Services.Users
{
    public interface IUserService: IBaseService<User>
    {
        User GetSingle(Expression<Func<User, bool>> predicate);

        bool IsUsernameUnique(string username);
        bool isEmailUnique(string email);
    }
}
