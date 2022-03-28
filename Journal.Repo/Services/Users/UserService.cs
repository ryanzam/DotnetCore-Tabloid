using Journal.Repository.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Journal.Repository.Services.Users
{
    public class UserService : BaseService<User>, IUserService
    {
        //private readonly JournalContext _context;
        public UserService(JournalContext context): base(context)
        {
            //_context = context;
        }
        public User GetSingle(Expression<Func<User, bool>> predicate)
        {
            return _context.Set<User>().FirstOrDefault(predicate);
        }

        public bool isEmailUnique(string email)
        {
            var user = GetSingle(u => u.Email == email);
            return user == null;
        }

        public bool IsUsernameUnique(string username)
        {
            var user = GetSingle(u => u.Username == username);
            return user == null;
        }
    }
}
