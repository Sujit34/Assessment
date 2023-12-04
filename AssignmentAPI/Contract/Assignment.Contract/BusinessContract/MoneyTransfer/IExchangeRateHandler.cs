using Assignment.Contract.DataModels.MoneyTransfer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Contract.BusinessContract.MoneyTransfer
{
    public interface IExchangeRateHandler
    {
        Task<List<PartnerRateDto>> GetExchangeRate(string country);
    }
}
