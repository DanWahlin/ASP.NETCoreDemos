using UsingEntityFrameworkCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsingEntityFrameworkCore.Repository {

    public interface ICustomersRepository 
    {     
        Task<Customer> InsertAndRetrieveCustomerAsync();
        Task<List<Customer>> GetCustomersAsync();
    }

}