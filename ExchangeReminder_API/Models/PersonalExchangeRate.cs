using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeReminder_API.Models
{
    public class PersonalExchangeRate : BaseEntity
    {
        [Column("personal_rate")]
        public decimal PersonalRate { get; set; }

        [Column("exchange_type")]
        public string ExchangeType { get; set; }

        [Column("exchange_increase")]
        public decimal ExchangeIncrease{ get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
