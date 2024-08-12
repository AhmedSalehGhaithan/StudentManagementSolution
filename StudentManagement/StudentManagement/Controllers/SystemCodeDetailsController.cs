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
    public class SystemCodeDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SystemCodeDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemCodeDetails
        [HttpGet("All-SystemCodeDetails")]
        public async Task<ActionResult<IEnumerable<SystemCodeDetailTable>>> GetAllSystemCodesDetailAsync()
        {
            return await _context.SystemCodesDetailsTable.ToListAsync();
        }

        // GET: api/SystemCodeDetails/5
        [HttpGet("Single-SystemCodeDetails/{id}")]
        public async Task<ActionResult<SystemCodeDetailTable>> GetSystemCodeDetailByIdAsync(int id)
        {
            var systemCodeDetail = await _context.SystemCodesDetailsTable.FindAsync(id);

            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            return systemCodeDetail;
        }

        // PUT: api/SystemCodeDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update-SystemCodeDetails")]
        public async Task<IActionResult> UpdateSystemCodeDetailAsync(int id, SystemCodeDetailTable systemCodeDetail)
        {
            if (id != systemCodeDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemCodeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemCodeDetailExistsAsync(id))
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

        // POST: api/SystemCodeDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Add-SystemCodeDetails")]
        public async Task<ActionResult<SystemCodeDetailTable>> AddSystemCodeDetailAsync(SystemCodeDetailTable systemCodeDetail)
        {
            _context.SystemCodesDetailsTable.Add(systemCodeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemCodeDetail", new { id = systemCodeDetail.Id }, systemCodeDetail);
        }

        // DELETE: api/SystemCodeDetails/5
        [HttpDelete("Delete-SystemCodeDetails/{id}")]
        public async Task<IActionResult> DeleteSystemCodeDetailAsync(int id)
        {
            var systemCodeDetail = await _context.SystemCodesDetailsTable.FindAsync(id);
            if (systemCodeDetail == null)
            {
                return NotFound();
            }

            _context.SystemCodesDetailsTable.Remove(systemCodeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemCodeDetailExistsAsync(int id)
        {
            return _context.SystemCodesDetailsTable.Any(e => e.Id == id);
        }
    }
}
