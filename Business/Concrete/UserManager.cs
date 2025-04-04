
using Core.Interceptors.Utilities.Results;
using DataAccess;
using Entities.Concrete;

namespace Business
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAllUser()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"Kullanıcılar listelendi");
        }

        public IDataResult<User> GetUser(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id), "Kullanıcı bilgiileri getirildi");
        }
    }
}
