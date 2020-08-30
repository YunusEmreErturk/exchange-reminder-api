using ExchangeReminder_API.Interface;
using ExchangeReminder_API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeReminder_API.Helpers
{
    public class UserOperation : IUserOperation
    {
        private readonly DatabaseContext dbContext;
        public UserOperation(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> RegisterUser(JObject data)
        {
            //var returnModel = new JObject();
            //returnModel["error"] = false;
            //returnModel["message"] = "";

            string name = (string)data["name"];
            string lastname = (string)data["lastname"];
            string email = (string)data["email"];
            string password = (string)data["password"];

            var isUserAlreadyHave = await dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (isUserAlreadyHave == null)
            {

                User registerUser = new User();
                registerUser.Name = name;
                registerUser.SureName = lastname;
                registerUser.Email = email;
                registerUser.Password = password;

                dbContext.Users.Add(registerUser);

                await dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<User> GetCurrentUser(string email)
        {
            var isUserAlreadyHave = await dbContext.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            return isUserAlreadyHave;
        }

    }
}
