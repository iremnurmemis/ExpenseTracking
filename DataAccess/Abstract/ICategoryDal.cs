

using Core.DataAccess.EntityFramework;
using Entities;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
      
    }
}
