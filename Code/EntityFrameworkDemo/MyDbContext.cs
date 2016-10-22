using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Data Source=localhost;Initial Catalog=EntityFrameworkDemo;Integrated Security=True")
        {

        }

        public DbSet<Person> People { get; set; }
    }
}
