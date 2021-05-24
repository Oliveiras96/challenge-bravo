using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Data;
using src.Models;

namespace src.Controllers
{
    [Route("api/currencies")]
    [EnableCors("_allowAnyOrigins")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly CurrencyConvertionContext _context;

        public CurrenciesController(CurrencyConvertionContext context)
        {
            _context = context;
        }

        // GET: api/Currencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntriesModelInput>>> GetEntriesModel()
        {
            return await _context.EntriesModel.ToListAsync();
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntriesModelInput>> GetEntriesModelInput(int id)
        {
            var entriesModelInput = await _context.EntriesModel.FindAsync(id);

            if (entriesModelInput == null)
            {
                return NotFound();
            }

            return entriesModelInput;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntriesModelInput(int id, EntriesModelInput entriesModelInput)
        {
            if (id != entriesModelInput.Id)
            {
                return BadRequest();
            }

            _context.Entry(entriesModelInput).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntriesModelInputExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EntriesModelInput>> PostEntriesModelInput(EntriesModelInput entriesModelInput)
        {
            _context.EntriesModel.Add(entriesModelInput);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntriesModelInput", new { id = entriesModelInput.Id }, entriesModelInput);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntriesModelInput(int id)
        {
            var entriesModelInput = await _context.EntriesModel.FindAsync(id);
            if (entriesModelInput == null)
            {
                return NotFound();
            }

            _context.EntriesModel.Remove(entriesModelInput);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntriesModelInputExists(int id)
        {
            return _context.EntriesModel.Any(e => e.Id == id);
        }
    }
}
