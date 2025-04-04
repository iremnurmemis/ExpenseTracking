
using Core.Interceptors.Utilities.Results;
using Entities.Concrete;

namespace Business
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAllUser();
        IDataResult<User> GetUser(int id);  
    }
}
