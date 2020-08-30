using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeReminder_API.Helpers
{
    public interface IExchangeOperation
    {
        Task<bool> CreateExchangeRecord(JObject data);
        
    }
}
