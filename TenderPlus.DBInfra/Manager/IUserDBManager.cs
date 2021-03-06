﻿using System.Threading.Tasks;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.DBInfra.Manager
{
    public interface IUserDBManager
    {
        Task<User> GetDBUser();
        Task<bool> CreateDBUser(User user);
        Task<User> UpdateDBUser();
    }
}
