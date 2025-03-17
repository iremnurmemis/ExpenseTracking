using Core.Interceptors.Utilities.Results;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        IResult Add(Expense expense);
        IResult Delete(int id);
        IResult Update(Expense expense);
        IDataResult<List<Expense>> GetAll();
        IDataResult<Expense> GetById(int id);
        

    }
}
