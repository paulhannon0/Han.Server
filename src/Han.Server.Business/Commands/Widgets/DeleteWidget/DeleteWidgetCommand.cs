using System.Net;
using System.Threading.Tasks;
using Han.Server.Business.Models.Widgets;
using Han.Server.Business.Models.Widgets.DeleteWidget;
using Han.Server.Common.Exceptions;
using Han.Server.Data.Repositories;

namespace Han.Server.Business.Commands.Widgets.DeleteWidget
{
    public class DeleteWidgetCommand : IDeleteWidgetCommand
    {
        private readonly IWidgetsRepository widgetsRepository;

        public DeleteWidgetCommand(IWidgetsRepository widgetsRepository)
        {
            this.widgetsRepository = widgetsRepository;
        }

        public async Task<ulong> ExecuteAsync(DeleteWidgetCommandRequestModel commandRequest)
        {
            var widget = await this.widgetsRepository.GetAsync(commandRequest.Id);

            if (widget == null)
            {
                throw new HttpException(HttpStatusCode.NotFound, $"Widget (ID: {commandRequest.Id}) cannot be found.");
            }

            await this.widgetsRepository.DeleteAsync(commandRequest.Id);

            return commandRequest.Id;
        }
    }
}
