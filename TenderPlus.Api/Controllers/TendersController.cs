using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.Core.Manager;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly TenderPlusDBContext _context;
        private readonly ITenderCoreManager _tenderCore;

        public TendersController(TenderPlusDBContext context,ITenderCoreManager tenderCore)
        {
            _context = context;
            _tenderCore = tenderCore;
        }

        // GET: api/Tenders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TenderCore>>> GetTender()
        {
            IEnumerable<TenderCore> result = await _tenderCore.GetTenderList();
            return Ok(result);
          
        }

        // GET: api/Tenders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tender>> GetTender(int id)
        {
            var tender = await _context.Tender.FindAsync(id);

            if (tender == null)
            {
                return NotFound();
            }

            return tender;
        }

        // PUT: api/Tenders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateTender(TenderCore tender)
        {
            bool result = await _tenderCore.UpdateTender(tender);
            return Ok(result);
        }

        // POST: api/Tenders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<bool>> PostTender(TenderCore tender)
        {
            bool result = await _tenderCore.CreateTender(tender);
            return result;         
        }

        // DELETE: api/Tenders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteTender(int id)
        {
            bool result = await _tenderCore.DeleteTender(id);
            return result;
           
        }

        private bool TenderExists(int id)
        {
            return _context.Tender.Any(e => e.Id == id);
        }
    }
}
