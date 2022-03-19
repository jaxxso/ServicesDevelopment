using Microsoft.EntityFrameworkCore;
using NetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetBank.DataAccess
{
    public class ReportedCardBL
    {
        private readonly ReportedCardDA _reportedCardDA;

        public ReportedCardBL(ReportedCardDA reportedCardDA)
        {
            this._reportedCardDA = reportedCardDA;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            return await _appDbContext.ReportedCards.ToListAsync();

        }
        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingIssuingNetworkName)
        {
            return await _appDbContext.ReportedCards.Where(rc => rc.IssuingNetwork == issuingIssuingNetworkName).ToListAsync();

        }
        public async Task<ReportedCard> GetReportedCard(string CreditCardNumber)
        {
            return await _appDbContext.ReportedCards.FirstOrDefaultAsync(rc => rc.CreditCardNumber == CreditCardNumber);

        }
        public async Task<string> PutCreditCardReactivated(string CreditCardNumber)
        {
            var reportedCard = await _appDbContext.ReportedCards.FirstOrDefaultAsync(rc => rc.CreditCardNumber == CreditCardNumber);


            if (reportedCard is null)
            {
                return "Credit Card Not found";
            }

            reportedCard.StatusCard = "Recovered";
            reportedCard.LastUpdatedDate = DateTime.Now;
            await _appDbContext.SaveChangesAsync();

            return "Card Recovered";

        }

    }
}