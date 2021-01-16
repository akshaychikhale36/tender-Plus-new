using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public TendersController(TenderPlusDBContext context, ITenderCoreManager tenderCore)
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

        [HttpPost]
        [Route("tenderregister")]
        public async Task<IActionResult> RegisterTender(TenderUsersCore tenderCore)
        {
            bool result = await _tenderCore.RegisterTender(tenderCore.TenderId, tenderCore.RegisteredUsers);
            return Ok(result);
        }

        [HttpGet]
        [Route("getregisters/{tenderid}")]
        public async Task<ActionResult<TenderCore>> GetRegisters(int tenderid)
        {
            TenderCore result = await _tenderCore.GetRegisters(tenderid);
            return Ok(result);
        }

        [HttpGet]
        [Route("getuserregisters/{userId}")]
        public async Task<ActionResult<TenderCore>> getUserRegisters(int userId)
        {
            IEnumerable<TenderCore> result = await _tenderCore.getUserRegisters(userId);
            return Ok(result);
        }
        [HttpGet]
        [Route("getuserassign/{userId}")]
        public async Task<ActionResult<TenderCore>> getUserAssign(int userId)
        {
            IEnumerable<TenderCore> result = await _tenderCore.getUserAssign(userId);
            return Ok(result);
        }

        [HttpGet]
        [Route("gettenderbid/{tenderId}")]
        public async Task<ActionResult<int>> getTenderBid(int tenderId)
        {
            int result = await _tenderCore.getTenderBid(tenderId);
            return Ok(result);
        }

        [HttpPost]
        [Route("posttenderbid")]
        public async Task<ActionResult<int>> postTenderBid([FromForm]string tenderId, [FromForm] string userId, [FromForm] string finalBid)
        {

            int result = await _tenderCore.postTenderBid(Convert.ToInt32( tenderId), Convert.ToInt32(userId), Convert.ToInt32(finalBid));
            return Ok(result);
        }



        [HttpGet]
        [Route("getuserprogresstender/{userId}")]
        public async Task<ActionResult<TenderCore>> getuserprogresstender(int userId)
        {
            IEnumerable<TenderCore> result = await _tenderCore.getuserprogresstender(userId);
            return Ok(result);
        }

        [HttpPost]
        [Route("paytenderbid")]
        public async Task<ActionResult<bool>> paytenderbid([FromForm]string tenderId, [FromForm] string userId)
        {

            bool result = await _tenderCore.paytenderbid(Convert.ToInt32(tenderId), Convert.ToInt32(userId));
            return Ok(result);
        }

    }
}
