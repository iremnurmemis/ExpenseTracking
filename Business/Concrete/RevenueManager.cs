
using Core.Interceptors.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business
{
    public class RevenueManager : RevenueService
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

        public IResult Update(Revenue revenue)
        {
            _revenueDal.Update(revenue);
            return new SuccessDataResult<Revenue>(revenue, "gelir güncellendi");
        }
    }
}
