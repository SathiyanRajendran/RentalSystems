using RentalSystems.Models;
using System.Collections.Generic;
using System.Linq;

namespace RentalSystems.DataLayer
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly OwnerDbContext db;
        public CustomerRepo(OwnerDbContext _db)
        {
            db = _db;
        }
        public void DeleteCustomer(int customerid)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomerByID(int customerid)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return db.customers.ToList();

        }

        public void InsertCustomer(Customer customer)
        {
            db.customers.Add(customer);
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
