using System.Threading.Tasks;

namespace Han.Server.Business.Commands
{
    public interface ICommand<TCommandRequest, TCommandResponse>
    {
        Task<TCommandResponse> ExecuteAsync(TCommandRequest commandRequest);
    }
}
