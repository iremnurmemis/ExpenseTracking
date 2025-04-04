using Core.Interceptors.Utilities.Results;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        IResult Add(Expense expense);
        IResult Delete(int id);
        IResult Update(Expense expense);
        IDataResult<List<Expense>> GetAll();
        IDataResult<Expense> GetById(int id);
        IDataResult<List<Expense>> GetUserExpenses(int userId);
        IDataResult<List<Expense>> GetExpensesByCategory(int categoryId);
        IDataResult<List<Expense>> GetExpensesByUserAndCategory(int userId, int categoryId);
        IDataResult<double> GetTotalExpense(int userId);  //zaman ile filtreleyebiliriz
       

        //IDataResult<List<Expense>> GetExpensesByDateRange(DateTime startDate, DateTime endDate);
        //IDataResult<decimal> GetTotalExpense(int userId); //KULLANICI TOPLAM GİDERİ HESAPLAR BUNU ZAMAN İLE FİLTRELE

    }
}
