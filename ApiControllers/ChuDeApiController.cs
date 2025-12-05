using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proMvcApi.Data;
using proMvcApi.Models;

namespace proMvcApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuDeApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChuDeApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ChuDeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChuDe>>> GetChuDes()
        {
            return await _context.ChuDes.ToListAsync();
        }

        // GET: api/ChuDeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChuDe>> GetChuDe(int id)
        {
            var chuDe = await _context.ChuDes.FindAsync(id);

            if (chuDe == null)
            {
                return NotFound();
            }

            return chuDe;
        }

        // PUT: api/ChuDeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChuDe(int id, ChuDe chuDe)
        {
            if (id != chuDe.MaChuDe)
            {
                return BadRequest();
            }

            _context.Entry(chuDe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuDeExists(id))
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

        // POST: api/ChuDeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChuDe>> PostChuDe(ChuDe chuDe)
        {
            _context.ChuDes.Add(chuDe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChuDe", new { id = chuDe.MaChuDe }, chuDe);
        }

        // DELETE: api/ChuDeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChuDe(int id)
        {
            var chuDe = await _context.ChuDes.FindAsync(id);
            if (chuDe == null)
            {
                return NotFound();
            }

            _context.ChuDes.Remove(chuDe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChuDeExists(int id)
        {
            return _context.ChuDes.Any(e => e.MaChuDe == id);
        }
    }
}
