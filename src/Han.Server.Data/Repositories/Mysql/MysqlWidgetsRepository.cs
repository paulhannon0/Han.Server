using System.Threading.Tasks;
using Han.Server.Data.Models;

namespace Han.Server.Data.Repositories.Mysql
{
    public class WidgetsRepository : IWidgetsRepository
    {
        public async Task<ulong> CreateAsync(WidgetRecord widget)
        {
            return await RepositoryHelper.InsertAsync<WidgetRecord>(widget);
        }

        public async Task<WidgetRecord> GetAsync(ulong id)
        {
            return await RepositoryHelper.GetByIdAsync<WidgetRecord>(id);
        }

        public async Task UpdateAsync(WidgetRecord widget)
        {
            await RepositoryHelper.UpdateAsync<WidgetRecord>(widget);
        }

        public async Task DeleteAsync(ulong id)
        {
            await RepositoryHelper.DeleteAsync<WidgetRecord>
            (
                new WidgetRecord
                {
                    Id = id
                }
            );
        }
    }
}
