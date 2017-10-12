using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TestAspNet.Domain.Entities;
using TestAspNet.Domain.Repositories;

namespace TestAspNet.Domain.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _repository.Query()
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToListAsync();
        }
    }
}