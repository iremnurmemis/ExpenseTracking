using Core.DataAccess.EntityFramework;
using DataAccess.Concrete;
using Entities;
using System.Linq.Expressions;


namespace DataAccess
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ExpenseTrackingContext>, ICategoryDal
    {
      
    }
}
