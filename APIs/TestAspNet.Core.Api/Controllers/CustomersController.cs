using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAspNet.Domain.Commands.Handlers;
using TestAspNet.Domain.Commands.Inputs.Customer;
using TestAspNet.Domain.Validators;

namespace TestAspNet.Core.Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerCommandHandler _commandHandler;

        public CustomersController(CustomerCommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _commandHandler.ExecuteAsync(new GetCustomersCommand());
            return ProcessResult(result);
        }

        private JsonResult ProcessResult(MethodResult methodResult)
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