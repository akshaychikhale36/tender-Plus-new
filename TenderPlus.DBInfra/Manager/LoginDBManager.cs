﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public class LoginDBManager : ILoginDBManager
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public LoginDBManager(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;
        }

        private bool LoginExists(string username)
        {
            return _tenderPlusDBContext.Login.Any(e => e.UserName == username);
        }

        public async Task<string> CreateDBLogin(Login login)
        {
            _tenderPlusDBContext.Login.Add(login);
            try
            {
                await _tenderPlusDBContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.UserName))
                {
                    return "Already Present";
                }
                else
                {
                    throw;
                }
            }

            return "Success";
        }

        public async Task<Login> GetDBLogin(string username, string password)
        {
            //var login = from s in _tenderPlusDBContext.Login
            //            where EF.Functions.Like(s.UserName, "%" + username + "%")
            //            select s;


            var login = await _tenderPlusDBContext.Login.Where(x=>x.UserName==username&& x.Password==password).SingleOrDefaultAsync();
            return login;
        }

        public async Task<Login> GetDBLoginByUsername(string username)
        {
            var login = await _tenderPlusDBContext.Login.Where(x => x.UserName == username).SingleOrDefaultAsync();
            return login;
        }
    }
}
