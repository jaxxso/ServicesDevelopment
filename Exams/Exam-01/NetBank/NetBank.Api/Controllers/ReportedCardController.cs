using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBank.BusinessLogic;
using NetBank.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetBank.Api.Controllers
{
    [Route("api/v1.0/[controller]")]
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
            var reportedCards = await _reportedCardBL.GetAllReportedCards();
            if (reportedCards is null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            return Ok(await _reportedCardBL.GetAllReportedCards());
        }

        // GET: api/v1.0/<ReportedCardsController>
        [HttpGet("IssuingNetwork/{issuingNetworkName}")]
        public async Task<ActionResult<IList<ReportedCard>>> GetAllReportedCardsByIssuingNetworkName(string issuingNetworkName)
        {
            var _issuingNetworks = await _reportedCardBL.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName);
            if (_issuingNetworks is EmptyResult)
            {
                return NotFound("The Network " + issuingNetworkName + " is not exist");
            }
            return Ok(await _reportedCardBL.GetAllReportedCardsByIssuingNetworkName(issuingNetworkName));
        }

        // GET: api/v1.0/<ReportedCardsController>
        [HttpGet("{creditCardNumber}")]
        public async Task<ActionResult<IList<ReportedCard>>> GetReportedCard(string creditCardNumber)
        {
            var _creditCardNumber = await _reportedCardBL.GetReportedCard(creditCardNumber);
            if (_creditCardNumber is null)
            {
                NotFound("The Credit Card Number " + creditCardNumber + " is not exist");
            }

            return Ok(await _reportedCardBL.GetReportedCard(creditCardNumber));
        }

        [HttpPost("{creditCardNumber}")]
        public ActionResult<String> PostCheckCreditCardDigit(string creditCardNumber)
        {
            if (CreditCardBL.IsValid(creditCardNumber))
            {
                return Ok("Credit card is valid");
            }
            return BadRequest("Credit card is not valid");
        }

        [HttpPut("{creditCardNumber}")]
        public async Task<ActionResult<String>> PutCreditCardReactivated(string creditCardNumber)
        {
            return Ok(await _reportedCardBL.PutCreditCardReactivated(creditCardNumber));
        }
    }
}