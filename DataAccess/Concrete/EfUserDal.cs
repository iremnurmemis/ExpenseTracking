using Core.DataAccess.EntityFramework;
using DataAccess.Concrete;
using Entities.Concrete;
using System.Linq.Expressions;


namespace DataAccess
{
    public class EfUserDal : EfEntityRepositoryBase<User, ExpenseTrackingContext>, IUserDal
    {
      
    }
}
