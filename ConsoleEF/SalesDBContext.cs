using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF
{
    internal class SalesDBContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
