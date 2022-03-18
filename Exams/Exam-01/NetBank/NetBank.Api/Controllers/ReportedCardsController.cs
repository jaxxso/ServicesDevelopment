using Microsoft.AspNetCore.Mvc;
using NetBank.BusinessLogic;
using NetBank.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetBank.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class ReportedCardsController : ControllerBase
   {
      private readonly ReportedCardBL _reportedCardBL;

      public ReportedCardsController(ReportedCardBL reportedCardBL)
      {
         _reportedCardBL = reportedCardBL;
      }

      // GET: api/v1.0/<ReportedCardsController>
      [HttpGet]
      public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCards()
      {
         return Ok(await _reportedCardBL.GetAllReportedCards());
      }

      // GET: api/v1.0/<ReportedCardsController>/IssuingNetwork/{issuingNetworkName}
      [HttpGet("IssuingNetwork/{issuingNetworkName}")]
      public async Task<ActionResult<IEnumerable<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
      {
         return Ok(await _reportedCardBL.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
      }

      // GET api/<ReportedCardsController>/{creditCardNumber}
      [HttpGet("{creditCardNumber}")]
      public async Task<ActionResult<ReportedCard>> GetReportedCard(string creditCardNumber)
      {
         return Ok(await _reportedCardBL.GetReportedCard(creditCardNumber));
      }

      // POST api/v1.0/<ReportedCardsController>/{creditCardNumber}
      [HttpPost("{creditCardNumber}")]
      public ActionResult<string> PostCheckCreditCardDigit(string creditCardNumber)
      {
         if (CreditCardBL.IsValid(creditCardNumber))
         {
            return Ok("Credit Card Is Valid");
         }

         return Ok("Credit Card Is NOT Valid");
      }

      // PUT api/v1.0/<ReportedCardsController>/{creditCardNumber}
      [HttpPut("{creditCardNumber}")]
      public async Task<ActionResult<string>> PutCreditCardReactivated(string creditCardNumber)
      {
         return Ok(await _reportedCardBL.PutCreditCardReactivated(creditCardNumber));
      }
   }
}
