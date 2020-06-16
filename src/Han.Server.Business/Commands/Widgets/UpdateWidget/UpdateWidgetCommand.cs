using System.Threading.Tasks;
using Han.Server.Business.Models.Widgets;
using Han.Server.Business.Models.Widgets.UpdateWidget;
using Han.Server.Data.Repositories;

namespace Han.Server.Business.Commands.Widgets.UpdateWidget
{
    public class UpdateWidgetCommand : IUpdateWidgetCommand
    {
        private readonly IWidgetsRepository widgetsRepository;

        public UpdateWidgetCommand(IWidgetsRepository widgetsRepository)
        {
            this.widgetsRepository = widgetsRepository;
        }

        public async Task<ulong> ExecuteAsync(UpdateWidgetCommandRequestModel commandRequest)
        {
            var widget = new Widget
            {
                Id = commandRequest.Id,
                Name = commandRequest.Name
            };

            await this.widgetsRepository.UpdateAsync(widget.ToTableRecord());

            return widget.Id;
        }
    }
}
