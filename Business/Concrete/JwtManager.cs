using Core.Interceptors.Utilities.Results;
using DataAccess;
using Entities;
using Entities.Concrete;
using Entities.Concrete.AuthOperations;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business
{
    public class JwtManager : IJwtHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenDal _refreshTokenDal;
        private readonly IUserDal _userDal;

        public JwtManager(IConfiguration configuration, IUserDal userDal, IRefreshTokenDal refreshTokenDal)
        {
            _configuration = configuration;
            _userDal = userDal;
            _refreshTokenDal = refreshTokenDal;
        }


        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature); // Signature eklendi

            var claims = new[]
            {
        new System.Security.Claims.Claim(ClaimTypes.Name, user.UserName),
        new System.Security.Claims.Claim(ClaimTypes.Email, user.Email),
        new System.Security.Claims.Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

            var token = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(jwtSettings.ExpirationInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public string GenerateRefreshToken(User user)
        {
            var oldRefreshToken=_refreshTokenDal.Get(r=>r.UserId==user.Id);
            if (oldRefreshToken != null) 
            {
                _refreshTokenDal.Delete(oldRefreshToken);
            }

        

            var refreshTokenExpiration = DateTime.UtcNow.AddDays(30);

            var refreshToken= Guid.NewGuid().ToString();
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpireDate = refreshTokenExpiration,
                CreatedDate = DateTime.UtcNow
            };
           
            _refreshTokenDal.Add(refreshTokenEntity);
            return refreshToken;
        }
        public RefreshToken GetStoredRefreshToken(string refreshToken)
        {
            var storedToken = _refreshTokenDal.Get(r => r.Token == refreshToken);
            return storedToken ?? throw new Exception("Refresh token bulunamadı.");
        }



        //token gecerliliği kontrolü
        public IDataResult<string> RefreshToken(string refreshToken)
        {
            var storedRefreshToken = GetStoredRefreshToken(refreshToken);

            if (storedRefreshToken == null)
            {
                return new ErrorDataResult<string>("Geçersiz refresh token.");
            }

            if (storedRefreshToken.ExpireDate < DateTime.UtcNow)
            {
                return new ErrorDataResult<string>("Refresh token süresi dolmuş.");
            }

            var user = _userDal.Get(u => u.Id == storedRefreshToken.UserId);
            if (user == null)
            {
                return new ErrorDataResult<string>("Kullanıcı bulunamadı.");
            }

            var newAccessToken = GenerateJwtToken(user);  // Yeni access token oluştur

            return new SuccessDataResult<string>(newAccessToken, "Yeni access token alındı.");
        }


    }
}
