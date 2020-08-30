using ExchangeReminder_API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeReminder_API.Interface
{
    public interface IUserOperation
    {
        Task<bool> RegisterUser(JObject data);
        Task<User> GetCurrentUser(string email);
    }
}
