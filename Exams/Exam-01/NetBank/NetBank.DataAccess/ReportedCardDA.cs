﻿using Microsoft.EntityFrameworkCore;
using NetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetBank.DataAccess
{
   public class ReportedCardDA
   {
      private readonly AppDbContext _dbContext;

      public ReportedCardDA(AppDbContext dbContext)
      {
         _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
      }

      public async Task<IList<ReportedCard>> GetAllReportedCards()
      {
         return await _dbContext.ReportedCards.ToListAsync();
      }

      public async Task<IList<ReportedCard>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return await _dbContext.ReportedCards.Where(item => item.IssuingNetwork == issuingNetworkName).ToListAsync();
      }

      public async Task<ReportedCard> GetReportedCard(string creditCardNumber)
      {
         return await _dbContext.ReportedCards.FirstOrDefaultAsync(item => item.CreditCardNumber == creditCardNumber);
      }

      public async Task<string> PutCreditCardReactivated(string creditCardNumber)
      {
         var reportedCard = await _dbContext.ReportedCards.FirstOrDefaultAsync(item => item.CreditCardNumber == creditCardNumber);

         if (reportedCard != null)
         {
            reportedCard.StatusCard = "Recovered";
            reportedCard.LastUpdatedDate = DateTime.Now;

            await _dbContext.SaveChangesAsync();
            return "Credit Card Recovered";
         }

         return "Credit Card Not Found";
      }
   }
}
