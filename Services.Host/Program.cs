using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationServer.Http.Activation;
using Microsoft.ApplicationServer.Http.Description;

namespace Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost = new HttpConfigurableServiceHost<CustomerService>(HttpHostConfiguration.Create(), new Uri[] { new Uri("http://localhost:1234/customers") });
            serviceHost.Open();
            Console.WriteLine("Service Started..");
            Console.ReadLine();
            serviceHost.Close();
        }
    }
}
