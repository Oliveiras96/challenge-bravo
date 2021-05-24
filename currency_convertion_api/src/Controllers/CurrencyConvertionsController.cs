using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using src.Data;
using src.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace src.Controllers
{
    [Route("api/convert")]
    [EnableCors("_allowAnyOrigins")]
    [ApiController]
    public class CurrencyConvertionsController : ControllerBase
    {
        private readonly CurrencyConvertionContext _context;

        // Instantiate the model context:
        public CurrencyConvertionsController(CurrencyConvertionContext context)
        {
            _context = context;
        }

        // GET: api/
        [HttpGet]
        [SwaggerResponse(200,"Everything ok")]
        [SwaggerResponse(400,"BAD REQUEST")]
        public ActionResult Convert([FromQuery] string from, [FromQuery] string to, [FromQuery] double amount) 
        {   

            // TODO: Validate request data; 
            var currencies = _context.EntriesModel.ToList<EntriesModelInput>();

            if(!validEntries(from, to, currencies))
            {
                return BadRequest(new {
                    Message = "Incorrect Entry: currency type not exist on the database."
                });
            } 
            else if (amount < 0.0)
            {
                 return BadRequest(new {
                    Message = "Incorrect Entry: amount must be a positive number."
                });
            }

            // TODO: convert values: (Test with another currencies)
            var newValue = makeConvertion(from, to, amount, currencies);
            return Ok(new {
                Message = $"{amount} {from} = {newValue} {to}"
            });
        }

        public static bool validEntries(string from, string to, List<EntriesModelInput> currencies)
        {
            var isOriginValid = currencies.Contains(currencies.Find(c => c.ISOCode == from));
            var isDestinyValid = currencies.Contains(currencies.Find(c => c.ISOCode == to));

            return isDestinyValid && isDestinyValid;
        }

        public static double makeConvertion(string from, string to, double amount, List<EntriesModelInput> currencies)
        {
            var quotationNew = currencies.Find(curr => curr.ISOCode == to).Quotation;
            var quotationCurrent = currencies.Find(curr => curr.ISOCode == from).Quotation;

            var currentAmountInUsd = amount * quotationCurrent;

            return currentAmountInUsd / quotationNew;        
        }
    }
}