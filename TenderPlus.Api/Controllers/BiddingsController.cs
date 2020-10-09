using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.Core.Manager;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiddingsController : ControllerBase
    {
        private readonly TenderPlusDBContext _context;
        private readonly IBiddingCore _biddingCore;

        public BiddingsController(TenderPlusDBContext context,IBiddingCore biddingCore)
        {
            _context = context;
            _biddingCore = biddingCore;
        }

        // GET: api/Biddings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bidding>>> GetBidding()
        {
            return await _context.Bidding.ToListAsync();
        }

        // GET: api/Biddings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bidding>> GetBidding(int id)
        {
            var bidding = await _context.Bidding.FindAsync(id);

            if (bidding == null)
            {
                return NotFound();
            }

            return bidding;
        }

        // PUT: api/Biddings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBidding(int id, Bidding bidding)
        {
            if (id != bidding.TenderId)
            {
                return BadRequest();
            }

            _context.Entry(bidding).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiddingExists(id))
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

        // POST: api/Biddings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bidding>> PostBidding(Bidding bidding)
        {
            _context.Bidding.Add(bidding);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BiddingExists(bidding.TenderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBidding", new { id = bidding.TenderId }, bidding);
        }

        // DELETE: api/Biddings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bidding>> DeleteBidding(int id)
        {
            var bidding = await _context.Bidding.FindAsync(id);
            if (bidding == null)
            {
                return NotFound();
            }

            _context.Bidding.Remove(bidding);
            await _context.SaveChangesAsync();

            return bidding;
        }

        private bool BiddingExists(int id)
        {
            return _context.Bidding.Any(e => e.TenderId == id);
        }
    }
}
