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

        public Task<byte> ExecuteAsync(UpdateWidgetCommandRequestModel commandRequest)
        {
            var widget = new Widget
            {
                Name = commandRequest.Name
            };

            // repository call

            return Task.FromResult(new byte());
        }
    }
}
