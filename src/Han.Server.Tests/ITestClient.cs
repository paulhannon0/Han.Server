using System.Net.Http;
using System.Threading.Tasks;

namespace Han.Server.Tests
{
    public interface ITestClient
    {
        Task<HttpResponseMessage> PostAsync(string path, object body);

        Task<HttpResponseMessage> GetAsync(string path);
    }
}
