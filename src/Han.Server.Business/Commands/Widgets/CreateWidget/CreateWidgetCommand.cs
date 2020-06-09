using System.Net;
using System.Threading.Tasks;
using Han.Server.Business.Models;
using Han.Server.Common.Exceptions;
using Han.Server.Data.Repositories;

namespace Han.Server.Business.Commands.Widgets.CreateWidget
{
    public class CreateWidgetCommand : ICreateWidgetCommand
    {
        private readonly IWidgetsRepository widgetsRepository;

        public CreateWidgetCommand(IWidgetsRepository widgetsRepository)
        {
            this.widgetsRepository = widgetsRepository;
        }

        public async Task<ulong> ExecuteAsync(CreateWidgetCommandRequestModel commandRequest)
        {
            var widget = new Widget
            {
                Name = commandRequest.Name
            };

            return await this.widgetsRepository.CreateAsync(widget.ToTableRecord());
        }
    }
}
