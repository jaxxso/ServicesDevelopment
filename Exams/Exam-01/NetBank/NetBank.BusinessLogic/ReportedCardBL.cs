using NetBank.DataAccess;
using NetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetBank.BusinessLogic
{
    public class ReportedCardBL
    {
        private readonly ReportedCardDA _reportedCardDA;

        public ReportedCardBL (ReportedCardDA reportedcardDA )
        {
            _reportedCardDA = reportedcardDA;   
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            return await _reportedCardDA.GetAllReportedCards();

        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingIssuingNetworkName)
        {
            return await _reportedCardDA.GetAllReportedCardsByIssuingNetworkName(issuingIssuingNetworkName);

        }
        public async Task<ReportedCard> GetReportedCard(string CreditCardNumber)
        {
           return await _reportedCardDA.GetReportedCard(CreditCardNumber);

        }
        public async Task<string> PutCreditCardReactivated(string CreditCardNumber)
        {
            return await _reportedCardDA.PutCreditCardReactivated(CreditCardNumber);

        }
        }
}
