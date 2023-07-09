// Ignore Spelling: Coderz

using Coderz220.Models;
using Microsoft.EntityFrameworkCore;

namespace Coderz220.Data
{
    public class CoderzDbContext : DbContext
    {
        public CoderzDbContext(DbContextOptions<CoderzDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
