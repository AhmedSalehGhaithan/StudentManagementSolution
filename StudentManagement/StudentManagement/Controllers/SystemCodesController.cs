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
    public class SystemCodesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodes
        [HttpGet("All-SystemCode")]
        public async Task<ActionResult<IEnumerable<SystemCodeTable>>> GetAllSystemCodesAsync()
        {
            return await _context.SystemCodesTable.ToListAsync();
        }

        // GET: api/SystemCodes/5
        [HttpGet("Single-SystemCode/{id}")]
        public async Task<ActionResult<SystemCodeTable>> GetSystemCodeByIdAsync(int id)
        {
            var systemCode = await _context.SystemCodesTable.FindAsync(id);

            if (systemCode == null)
            {
                return NotFound();
            }

            return systemCode;
        }

        // PUT: api/SystemCodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-SystemCode")]
        public async Task<IActionResult> UpdateSystemCodeAsync(int id, SystemCodeTable systemCode)
        {
            if (id != systemCode.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeExistsAsync(id))
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

        // POST: api/SystemCodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-SystemCode")]
        public async Task<ActionResult<SystemCodeTable>> AddSystemCodeAsync(SystemCodeTable systemCode)
        {
            _context.SystemCodesTable.Add(systemCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCode", new { id = systemCode.Id }, systemCode);
        }

        // DELETE: api/SystemCodes/5
        [HttpDelete("Delete-SystemCode/{id}")]
        public async Task<IActionResult> DeleteSystemCodeAsync(int id)
        {
            var systemCode = await _context.SystemCodesTable.FindAsync(id);
            if (systemCode == null)
            {
                return NotFound();
            }

            _context.SystemCodesTable.Remove(systemCode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeExistsAsync(int id)
        {
            return _context.SystemCodesTable.Any(e => e.Id == id);
        }
    }
}
