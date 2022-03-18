using NetBank.DataAccess;
using NetBank.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetBank.BusinessLogic
{
   public class ReportedCardBL
   {
      private readonly ReportedCardDA _reportedCardDA;

      public ReportedCardBL(ReportedCardDA reportedCardDA)
      {
         _reportedCardDA = reportedCardDA;
      }

      public async Task<IList<ReportedCard>> GetAllReportedCards()
      {
         return await _reportedCardDA.GetAllReportedCards();
      }

      public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return await _reportedCardDA.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         return await _reportedCardDA.GetReportedCard(creditCardNumber);
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         return await _reportedCardDA.PutCreditCardReactivated(creditCardNumber);
      }
   }
}