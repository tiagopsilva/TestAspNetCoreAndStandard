using System.Threading.Tasks;
using TestAspNet.Domain.Commands.Inputs;
using TestAspNet.Domain.Validators;

namespace TestAspNet.Domain.Commands.Handlers
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task<MethodResult> ExecuteAsync(TCommand command);
    }
}