using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Services.Repository
{
    public class CustomerRepository
    {
        private List<Customer> customers;

        public CustomerRepository()
        {
            customers = new List<Customer>{ new Customer{ Id = 1, FirstName = "A", LastName = "A" }, new Customer{ Id = 2, FirstName = "B", LastName = "B" } };
        }

        public Customer Get(int id)
        {
            return customers.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public List<Customer>  All()
        {
            return customers;
        }
    }
}