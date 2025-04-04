

using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IUserDal : IEntityRepository<User>
    {
      
    }
}
