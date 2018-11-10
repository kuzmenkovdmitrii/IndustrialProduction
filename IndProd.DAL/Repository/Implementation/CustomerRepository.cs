using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IndProd.DAL.Domain;
using IndProd.DAL.Repository.Implementation;
using IndProd.DAL.Repository.Interface;

namespace IndProd.DAL.Repository
{
    class CustomerRepository : CommonRepository, ICustomerRepository
    {
        public IEnumerable<Customer> List()
        {
            return db.Customers;
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
            Save();
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            Customer customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                Save();
            }
        }
    }
}
