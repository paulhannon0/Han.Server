using System.Threading.Tasks;
using Han.Server.Data.Models;

namespace Han.Server.Data.Repositories
{
    public interface IWidgetsRepository
    {
        Task<ulong> CreateAsync(WidgetRecord widget);

        Task<WidgetRecord> GetAsync(ulong id);

        Task UpdateAsync(WidgetRecord widget);

        Task DeleteAsync(ulong id);
    }
}
