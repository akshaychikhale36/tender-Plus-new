using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TenderPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public string orderId { get; set; }
        //[Authorize] 
        [HttpPost]
        public async Task<ActionResult<bool>> payement(Dictionary<string, object> user)
        {
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
            return Ok(true);
        }
    }
}