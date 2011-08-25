using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Client;
using Domain;
using Microsoft.ApplicationServer.Http;
using Microsoft.ApplicationServer.Http.Activation;
using Microsoft.ApplicationServer.Http.Description;
using Services.Contract.Requests;
using Services.Contract.Responses;

namespace Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetMethod();
            PostMethod();
        }

        private static void GetMethod()
        {
            var customers = HttpClientFacade.GetJson<List<Customer>>("http://localhost:1234/customers/1");
            Console.ReadLine();
        }

        private static void PostMethod()
        {
            var request = new CanReactivateRequest
            {
                DateOfBirth = DateTime.Parse("01/01/1977"),
                EmailAddress = "abc@test.com",
                MemberId = Guid.NewGuid(),
                SocialSecurityNumber = "111-11-1111"
            };
            var response = HttpClientFacade.PostJson<CanReactivateRequest, CanReactivateResponse>("http://JBZJCP1:1234/customers/canreactivate", request);
            Console.WriteLine(response.EligibleForReactivation);
            Console.ReadLine();
        }
    }
}
