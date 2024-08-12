using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagementShared.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController(ApplicationDbContext _context) : ControllerBase
    {
     
        // GET: api/Countries
        [HttpGet("All-Countries")]
        public async Task<ActionResult<IEnumerable<CountryTable>>> GetAllCountriesAsync()
        {
            return await _context.CountriesTable.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("Single-Country/{id}")]
        public async Task<ActionResult<CountryTable>> GetCountryByIdAsync(int id)
        {
            var country = await _context.CountriesTable.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-Country")]
        public async Task<IActionResult> UpdateCountryAsync(int id, CountryTable country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExistsAsync(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-Country")]
        public async Task<ActionResult<CountryTable>> AddCountryAsync(CountryTable country)
        {
            _context.CountriesTable.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("Delete-Country/{id}")]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            var country = await _context.CountriesTable.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.CountriesTable.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExistsAsync(int id)
        {
            return _context.CountriesTable.Any(e => e.Id == id);
        }
    }
}
