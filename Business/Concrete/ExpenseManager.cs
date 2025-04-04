using Business.Abstract;
using Core.Interceptors.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IDataResult<List<Expense>> GetUserExpenses(int userId)
        {
            return new SuccessDataResult<List<Expense>>(_expenseDal.GetAll(e=>e.UserId==userId), "Kullanıcının harcamaları listelendi");
        }

        public IDataResult<List<Expense>> GetExpensesByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Expense>>(_expenseDal.GetAll(e => e.CategoryId==categoryId), "Kategoriye ait harcamalar listelendi");
        }

        public IDataResult<List<Expense>> GetExpensesByUserAndCategory(int userId, int categoryId)
        {
            return new SuccessDataResult<List<Expense>>(_expenseDal.GetAll(e => e.UserId == userId && e.CategoryId==categoryId) , "Kullanıcının harcamaları listelendi");

        }

        public IDataResult<double> GetTotalExpense(int userId)
        {
            var totalExpense=_expenseDal.GetAll(x=>x.UserId==userId).Sum(e=>e.ExpenseAmount);
            return new SuccessDataResult<double>(totalExpense, "Toplam harcama hesaplandı");
        }
    }
}
