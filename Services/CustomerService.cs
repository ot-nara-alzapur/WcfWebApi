using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Domain;
using Services.Contract.Requests;
using Services.Contract.Responses;
using Services.Repository;

namespace Services
{
    [ServiceContract]
    public class CustomerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "{id}")]
        public Customer Get(int id)
        {
            return new CustomerRepository().Get(id);
        }

        [OperationContract]
        [WebGet(UriTemplate = "")]
        public List<Customer> AllCustomers()
        {
            return new CustomerRepository().All();
        }

        [OperationContract]
        [WebInvoke(UriTemplate = "/canreactivate", Method = "POST")]
        public CanReactivateResponse CanReactivate(CanReactivateRequest request)
        {
            return new CanReactivateResponse {EligibleForReactivation = true};
        }
    }
}