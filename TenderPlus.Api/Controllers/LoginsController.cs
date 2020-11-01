using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenderPlus.Api.Authorize;
using TenderPlus.Core.Manager;
using TenderPlus.Core.Models;
using TenderPlus.DBInfra.Models;
using TenderPlus.Log;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly TenderPlusDBContext _context;
        private readonly ILoginCoreManager _loginCore;
        private IUserService _userService;
        private ILogger _logger;

        public LoginsController(TenderPlusDBContext context, ILoginCoreManager loginCore ,IUserService userService, ILogger logger)
        {
            _context = context;
            _loginCore = loginCore;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> GetLogin(AuthenticateRequest model)
        {

            //var login = await _loginCore.GetLogin(username, password);
            //_userService.Authenticate(model);

            //return Ok(login);
            try
            {
                var response = _userService.Authenticate(model);

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
