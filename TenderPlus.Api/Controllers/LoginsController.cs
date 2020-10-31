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
    public class LoginsController : ControllerBase
    {
        private readonly TenderPlusDBContext _context;
        private readonly ILoginCoreManager _loginCore;

        public LoginsController(TenderPlusDBContext context, ILoginCoreManager loginCore )
        {
            _context = context;
            _loginCore = loginCore;
        }

        // GET: api/Logins
        [HttpGet]
        public async Task<ActionResult<Login>> GetLogin(string username,string password)
        {

            var login = await _loginCore.GetLogin(username, password);
            return Ok(login);
        }


        // POST: api/Logins
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<string>> PostLogin(LoginCore login)
        {
            var result=await _loginCore.CreateLogin(login);
            return result;
        }
     
        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.Id == id);
        }
    }
}
