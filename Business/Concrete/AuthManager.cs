

using Core.Interceptors.Utilities.Results;
using DataAccess;
using DataAccess.Migrations;
using Entities;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Business
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly IJwtHelper _jwtHelper;
        public AuthManager(IUserDal userDal,IJwtHelper jwtHelper)
        {
            _userDal = userDal;
            _jwtHelper = jwtHelper;
        }

        public IDataResult<UserLoginDto> Login(UserLoginDto userLoginDto)
        {
            var user = _userDal.Get(u => u.Email == userLoginDto.Email);
            if (user == null)
            {
                return new ErrorDataResult<UserLoginDto>("Kullanıcı bulunamadı.");
            }

            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.Password))
            {
                return new ErrorDataResult<UserLoginDto>("Şifre yanlış.");
            }

            var token = _jwtHelper.GenerateJwtToken(user);
            var refreshToken = _jwtHelper.GenerateRefreshToken(user);
            userLoginDto.AccessToken = token;
            userLoginDto.RefreshToken=refreshToken;

            return new SuccessDataResult<UserLoginDto>(userLoginDto, "Giriş başarılı.");


        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {

            var userCheckResult = UserExist(userRegisterDto.Email);
            if (!userCheckResult.Success)
            {
                return new ErrorDataResult<User>("Bu e-posta adresi zaten kayıtlı.");
            }


            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

            var user = new User
            {
                Email = userRegisterDto.Email,
                Password = hashedPassword,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                CreatedDate=DateTime.UtcNow,
                UserName = userRegisterDto.UserName,
            };

            _userDal.Add(user);

            return new SuccessDataResult<User>(user, "Kullanıcı başarıyla kaydedildi.");
        }


        public IResult UserExist(string email)
        {
            var existingUser = _userDal.Get(u => u.Email == email);
            if (existingUser != null)
            {
                return new ErrorResult("Bu e-posta adresi zaten kayıtlı.");
            }
            return new SuccessResult("Kullanıcı mevcut değil.");
        }


      

    }
}
