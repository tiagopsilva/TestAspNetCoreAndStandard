using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TestAspNet.Domain.Commands.Handlers;
using TestAspNet.Domain.Commands.Inputs.Customer;
using TestAspNet.Domain.Validators;

namespace TestAspNet.Standard.Api.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly CustomerCommandHandler _commandHandler;

        public CustomersController(CustomerCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var result = await _commandHandler.ExecuteAsync(new GetCustomersCommand());
            return ProcessResult(result);
        }

        private IHttpActionResult ProcessResult(MethodResult methodResult)
        {
            if (methodResult.Failures.Any())
            {
                return Json(new
                {
                    success = false,
                    errors = methodResult.Failures.ToArray()
                });
            }
            else
            {
                return Json(new
                {
                    success = true,
                    data = methodResult.Data
                });
            }
        }
    }
}