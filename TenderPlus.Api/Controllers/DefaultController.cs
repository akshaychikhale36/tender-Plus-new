using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
         public async Task<IActionResult> GetVendorInvoices()
        {
            TenderPlusDBContext tbl = new TenderPlusDBContext();
           var data = tbl.Login;


            return  Ok(data);
        }
    }
}