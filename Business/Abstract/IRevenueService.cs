
using Core.Interceptors.Utilities.Results;
using Entities;

namespace Business
{
    public interface RevenueService
    {
        IResult Add(Revenue revenue);
        IResult Delete(int id);
        IResult Update(Revenue revenue);
        IDataResult<List<Revenue>> GetAll();
        IDataResult<Revenue> GetById(int id);


    }
}
