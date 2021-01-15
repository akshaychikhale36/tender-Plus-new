using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TenderPlus.Core.Provider;
using TenderPlus.DBInfra.Models;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly TenderPlusDBContext _tenderPlusDBContext;
        public PaymentController(TenderPlusDBContext tenderPlusDBContext)
        {
            _tenderPlusDBContext = tenderPlusDBContext;

        }
        public string orderId { get; set; }
        //[Authorize] 
        [HttpPost]
        public async Task<ActionResult<bool>> payement(Dictionary<string, object> user)
        {
            var number = await _tenderPlusDBContext.User.Where(x => x.Id == Convert.ToInt64(user.Values.ElementAt(0).ToString())).FirstOrDefaultAsync();

            Dictionary<string, object> input = new Dictionary<string, object>();
            input.Add("amount", 100); // this amount should be same as transaction amount
            input.Add("currency", "INR");
            input.Add("receipt", "12121");
            input.Add("payment_capture", 1);

            string key = "rzp_test_fcCzFVhnxp0Dqj";
            string secret = "GZ1M0BGLHyGNbCd4xi31IZJ6";

            RazorpayClient client = new RazorpayClient(key, secret);
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Razorpay.Api.Order order = client.Order.Create(input);
            orderId = order["id"].ToString();
            var message = "Thanks for the Payment against the tender of rs  "+ user.Values.ElementAt(4).ToString();
            SmsProvider.SendSms(number.Telephone, message);
            return Ok(true);
        }
    }
}