using System.Threading.Tasks;

namespace Han.Server.Business.Queries
{
    public interface IQuery<TQueryRequest, TQueryResponse>
    {
        Task<TQueryResponse> ExecuteAsync(TQueryRequest queryRequest);
    }
}
