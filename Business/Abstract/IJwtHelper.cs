
using Core.Interceptors.Utilities.Results;
using Entities;
using Entities.Concrete;

namespace Business
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);
        string GenerateRefreshToken(User user);

        RefreshToken GetStoredRefreshToken(string refreshToken);
        IDataResult<string> RefreshToken(string refreshToken); //süresi geçmişse yeni token olusturur

    }
}
