using RentalSystems.Models;
using System;
using System.Collections.Generic;

namespace RentalSystems.DataLayer
{
    public interface ICustomerRepo:IDisposable
    {
        IEnumerable<Customer> GetCustomers();
        Customer GetCustomerByID(int customerid);
        void InsertCustomer(Customer customer);
        void DeleteCustomer(int customerid);
        void UpdateCustomer(Customer customer);
        void Save();
    }
}
