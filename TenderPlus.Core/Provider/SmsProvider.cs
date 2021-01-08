using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TenderPlus.Core.Provider
{
    public class SmsProvider
    {
        public static bool SendSms(string number,string message)
        {
            var client = new RestClient("https://www.fast2sms.com/dev/bulk");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("authorization", "spQdBjDugE1YtFkXmLiUwT69nc2zerhvJKCH0fGyNSx8V34M5a0gIcjphm7xDOyw9FQ1vYEG8kAJB4V6");
            request.AddParameter("sender_id", "FSTSMS");
            request.AddParameter("message", message);
            request.AddParameter("language", "english");
            request.AddParameter("route", "p");
            request.AddParameter("numbers", "+91"+number);// remove +91
            IRestResponse response =client.Execute(request);
            if (response.IsSuccessful)
            {
                return true;
            }
            return false;
        }
    }
}
