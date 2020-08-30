using ExchangeReminder_API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeReminder_API.Helpers
{
    public class ExchangeOperation : IExchangeOperation
    {
        private readonly DatabaseContext dbContext;
        public ExchangeOperation(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CreateExchangeRecord(JObject data)
        {

            PersonalExchangeRate personalExchangeRate = new PersonalExchangeRate();
            personalExchangeRate.ExchangeType = (string)data["exchangeType"];
            personalExchangeRate.PersonalRate = (decimal)data["personalRate"];
            personalExchangeRate.ExchangeIncrease = (decimal)data["increaseOrDecrease"];
            try
            {
                dbContext.PersonalExchangeRates.Add(personalExchangeRate);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
    }
}
