
using Core.Interceptors.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business
{
    public class RevenueManager : IRevenueService
    {
        private readonly IRevenueDal _revenueDal;

        public RevenueManager(IRevenueDal revenueDal)
        {
            _revenueDal = revenueDal;
        }

        public IResult Add(Revenue revenue)
        {
            _revenueDal.Add(revenue);
            return new SuccessDataResult<Revenue>(revenue,"Gelir eklendi");
           
        }

        public IResult Delete(int id)
        {
           var revenue=_revenueDal.Get(r=>r.Id==id);
           _revenueDal.Delete(revenue);
            return new SuccessResult("gelir bilgisi silindi");


        }

        public IDataResult<List<Revenue>> GetAll()
        {
            return new SuccessDataResult<List<Revenue>>(_revenueDal.GetAll(),"listelendi");
        }

        public IDataResult<Revenue> GetById(int id)
        {
            return new SuccessDataResult<Revenue>(_revenueDal.Get(r => r.Id == id), "id ye göre geldi");
        }

        public IDataResult<List<Revenue>> GetRevenuesByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Revenue>>(_revenueDal.GetAll(r=>r.CategoryId==categoryId),"belirli kategoriye ait gelir bilgileri listelenmiştir");
        }

        public IDataResult<List<Revenue>> GetRevenuesByDateRange(DateTime startDate, DateTime endDate)
        {
            var revenues = _revenueDal.GetAll()
                .Where(r => r.RevenueDate >= startDate && r.RevenueDate <= endDate)
                .ToList();

            return new SuccessDataResult<List<Revenue>>(revenues, "Belirli tarih aralığındaki gelir bilgileri listelenmiştir.");
        }


        public IDataResult<List<Revenue>> GetRevenuesByUserAndCategory(int userId, int categoryId)
        {
            return new SuccessDataResult<List<Revenue>>(_revenueDal.GetAll(r => r.CategoryId == categoryId && r.UserId==userId), "belirli kullanıcıya ve kategoriye ait gelir bilgileri listelenmiştir");

        }

        public IDataResult<double> GetTotalRevenue(int userId)
       {
            var totalRevenue = _revenueDal.GetAll(r => r.UserId == userId).Sum(p => p.Amount);
            return new SuccessDataResult<double>(totalRevenue, "Toplam gelir hesaplandı.");
        }


        public IDataResult<List<Revenue>> GetUserRevenues(int userId)
        {
            return new SuccessDataResult<List<Revenue>>(_revenueDal.GetAll(r => r.UserId==userId), "Kullanıcıya ait gelir bilgileri listelenmiştir");

        }

        public IResult Update(Revenue revenue)
        {
            _revenueDal.Update(revenue);
            return new SuccessDataResult<Revenue>(revenue, "gelir güncellendi");
        }
    }
}
