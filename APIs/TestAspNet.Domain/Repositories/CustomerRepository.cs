using System.Linq;
using TestAspNet.Domain.Contexts;
using TestAspNet.Domain.Entities;

namespace TestAspNet.Domain.Repositories
{
    public class CustomerRepository
    {
        private readonly EntityContext _context;

        public CustomerRepository(EntityContext context)
        {
            _context = context;
        }

        public IQueryable<Customer> Query()
        {
            return _context.Customers;
        }
    }
}