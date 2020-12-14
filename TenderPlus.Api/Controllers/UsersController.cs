using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.Core.Manager;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;
using TenderPlus.Log;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly TenderPlusDBContext _context;
        private readonly IUserCoreManager _userCore;
        private ILogger _logger;

        public UsersController(TenderPlusDBContext context,IUserCoreManager userCore, ILogger logger)
        {
            _context = context;
            _userCore = userCore;
        }

        // GET: api/Users
      
        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(LoginCore user)
        {
           
            try
            {
                var response = await _userCore.CreateUser(user);

                if (response == null)
                    return BadRequest(new { message = "Error encountered in authorizing." });

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.Error("authenticate():" + e);
                return BadRequest(new { message = "Error encountered in authorizing." });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
