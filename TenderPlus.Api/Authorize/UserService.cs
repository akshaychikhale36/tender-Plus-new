using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using TenderPlus.Core.Manager;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api.Authorize
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);      
        LoginCore GetById(string username);
    }

    public class UserService : IUserService
    {
        private ILoginCoreManager _loginCoreManager;
        private readonly AppSettings _appSettings;
        public UserService(ILoginCoreManager loginCoreManager , IOptions<AppSettings> appSettings)
        {
            _loginCoreManager=loginCoreManager;
            _appSettings = appSettings.Value;
        }
        // TO DO: Move this to DB
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, hkey1 = "AngularUI", hkey2 = "ngcli8020" }
        //};
      

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _loginCoreManager.GetLogin(model.username,model.password).GetAwaiter().GetResult();
            //.SingleOrDefault(x => x.hkey1 == model.username && x.hkey2 == model.password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        // helper methods

        private string generateJwtToken(LoginCore user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(40),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        LoginCore IUserService.GetById(string username) => _loginCoreManager.GetLoginByusername(username).GetAwaiter().GetResult();
    }

    public class AuthenticateRequest
    {
        public string username { get; set; }

        public string password { get; set; }
    }
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(LoginCore user, string token)
        {
            Id = user.Id;
            username = user.UserName;
            Token = token;
        }

    }
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string username { get; set; }

    //    [JsonIgnore]
    //    public string password { get; set; }
    //}
}
