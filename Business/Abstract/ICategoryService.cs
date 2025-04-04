using Core.Interceptors.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetCategoryByCategoryId(int id);
    }
}
