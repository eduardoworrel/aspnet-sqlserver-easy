#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;

namespace aspnet_myqsl_easy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EasyDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EasyDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EasyData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EasyData>>> GetEasy()
        {
            return await _context.Easy.ToListAsync();
        }

        // GET: api/EasyData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EasyData>> GetEasyData(int id)
        {
            var easyData = await _context.Easy.FindAsync(id);

            if (easyData == null)
            {
                return NotFound();
            }

            return easyData;
        }

        // PUT: api/EasyData/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEasyData(int id, EasyData easyData)
        {
            if (id != easyData.Id)
            {
                return BadRequest();
            }

            _context.Entry(easyData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EasyDataExists(id))
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

        // POST: api/EasyData
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EasyData>> PostEasyData(EasyData easyData)
        {
            _context.Easy.Add(easyData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEasyData", new { id = easyData.Id }, easyData);
        }

        // DELETE: api/EasyData/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEasyData(int id)
        {
            var easyData = await _context.Easy.FindAsync(id);
            if (easyData == null)
            {
                return NotFound();
            }

            _context.Easy.Remove(easyData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EasyDataExists(int id)
        {
            return _context.Easy.Any(e => e.Id == id);
        }
    }
}
