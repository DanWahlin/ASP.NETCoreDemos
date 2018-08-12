using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UsingEntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;

namespace UsingEntityFrameworkCore.Repository {

    public class CustomersRepository : ICustomersRepository 
    {
        CustomersDbContext _context;

        public CustomersRepository(CustomersDbContext context) {
            _context = context;
        }
        
        public async Task<Customer> InsertAndRetrieveCustomerAsync() {
            var newCustomer = new Customer { Name="Michelle Thomas", City="Los Angeles" };
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            var customer = await _context.Customers.FirstOrDefaultAsync();
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync() {
            return await _context.Customers.ToListAsync();
        }
    }

}