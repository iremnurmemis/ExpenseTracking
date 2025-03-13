using Core.DataAccess.EntityFramework;
using DataAccess.Concrete;
using Entities;
using System.Linq.Expressions;


namespace DataAccess
{
    public class EfCategorydal : EfEntityRepositoryBase<Category, ExpenseTrackingContext>, ICategoryDal
    {
      
    }
}
