using System.Threading.Tasks;
using TestAspNet.Domain.Commands.Inputs.Customer;
using TestAspNet.Domain.Services;
using TestAspNet.Domain.Validators;

namespace TestAspNet.Domain.Commands.Handlers
{
    public class CustomerCommandHandler :
        ICommandHandler<GetCustomersCommand>
    {
        private readonly CustomerService _service;

        public CustomerCommandHandler(CustomerService service)
        {
            _service = service;
        }

        public async Task<MethodResult> ExecuteAsync(GetCustomersCommand command)
        {
            var custormers = await _service.GetAll();

            return new MethodResult(custormers);
        }
    }
}