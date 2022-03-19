﻿using Microsoft.EntityFrameworkCore;
using NetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NetBank.DataAccess
{
    public class ReportedCardDA
    {
        private readonly AppDbContext _appDbContext;

        public ReportedCardDA(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IList<ReportedCard>> GetAllReportedCards()
        {
            return await _appDbContext.ReportedCards.ToListAsync();

        }

        public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingIssuingNetworkName)
        {
            return await _appDbContext.ReportedCards.Where(rc => rc.IssuingNetwork == issuingIssuingNetworkName).ToListAsync();

        }

        public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
        {
            return await _appDbContext.ReportedCards.FirstOrDefaultAsync(rc => rc.CreditCardNumber == creditCardNumber);

        }

        public async Task<string> PutCreditCardReactivated(string creditCardNumber)
        {
            var reportedCard = await _appDbContext.ReportedCards.FirstOrDefaultAsync(rc => rc.CreditCardNumber == creditCardNumber);


            if (reportedCard != null)
            {
                reportedCard.StatusCard = "Recovered";
                reportedCard.LastUpdatedDate = DateTime.Now;
                await _appDbContext.SaveChangesAsync();

                return "Credit Card Recovered";
            }

            return "Credit Card Not found";


        }
    }
}
