using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularBudget.Data;
using AngularBudget.Models;

namespace AngularBudget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FrequenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Frequencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Frequency>>> GetFrequency()
        {
            return await _context.Frequency.ToListAsync();
        }

        // GET: api/Frequencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frequency>> GetFrequency(int id)
        {
            var frequency = await _context.Frequency.FindAsync(id);

            if (frequency == null)
            {
                return NotFound();
            }

            return frequency;
        }

        //// PUT: api/Frequencies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutFrequency(int id, Frequency frequency)
        //{
        //    if (id != frequency.FrequencyId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(frequency).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FrequencyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Frequencies
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Frequency>> PostFrequency(Frequency frequency)
        //{
        //    _context.Frequency.Add(frequency);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFrequency", new { id = frequency.FrequencyId }, frequency);
        //}

        //// DELETE: api/Frequencies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFrequency(int id)
        //{
        //    var frequency = await _context.Frequency.FindAsync(id);
        //    if (frequency == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Frequency.Remove(frequency);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool FrequencyExists(int id)
        //{
        //    return _context.Frequency.Any(e => e.FrequencyId == id);
        //}
    }
}
