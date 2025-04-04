
using Core.Interceptors.Utilities.Results;
using Entities;

namespace Business
{
    public interface IRevenueService
    {
        IResult Add(Revenue revenue);
        IResult Delete(int id);
        IResult Update(Revenue revenue);
        IDataResult<List<Revenue>> GetAll();
        IDataResult<Revenue> GetById(int id);
        IDataResult<List<Revenue>> GetUserRevenues(int userId);
        IDataResult<List<Revenue>> GetRevenuesByCategory(int categoryId);
        IDataResult<List<Revenue>> GetRevenuesByDateRange(DateTime startDate, DateTime endDate);
        IDataResult<List<Revenue>> GetRevenuesByUserAndCategory(int userId, int categoryId);
        IDataResult<double> GetTotalRevenue(int userId); //KULLANICI TOPLAM GELİRİ HESAPLAR BUNU ZAMAN İLE FİLTRELE

    }
}
