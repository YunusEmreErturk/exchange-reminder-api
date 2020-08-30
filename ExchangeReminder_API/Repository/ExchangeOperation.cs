using ExchangeReminder_API.Models;
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

        public string selam()
        {
            throw new NotImplementedException();
        }
    }
}
