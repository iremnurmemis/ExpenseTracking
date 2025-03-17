using Business.Abstract;
using Core.Interceptors.Utilities.Results;
using DataAccess;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public IResult Add(Expense expense)
        {
            _expenseDal.Add(expense);
            return new SuccessResult("Gider Bilgisi Eklendi");
        }

        public IResult Update(Expense expense)
        {
            _expenseDal.Update(expense);
            return new SuccessResult("Gider Bilgisi Güncellendi");
        }

        public IResult Delete(int id)
        {
            var expense = _expenseDal.Get(x => x.Id == id);
            _expenseDal.Delete(expense);
            return new SuccessResult("Gider Bilgisi Silindi");
        }

        public IDataResult<List<Expense>> GetAll()
        {
            var values = _expenseDal.GetAll();
            return new SuccessDataResult<List<Expense>>(values, "Listelendi");
        }

        public IDataResult<Expense> GetById(int id)
        {
            var value = _expenseDal.Get(x => x.Id == id);
            return new SuccessDataResult<Expense>(value, "Listelendi");
        }
    }
}
