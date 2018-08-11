using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsingWebAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
