using Core.DataAccess.EntityFramework;
using DataAccess.Concrete;
using Entities;
using System.Linq.Expressions;


namespace DataAccess
{
    public class EfRefreshTokenDal : EfEntityRepositoryBase<RefreshToken, ExpenseTrackingContext>, IRefreshTokenDal
    {
      
    }
}
