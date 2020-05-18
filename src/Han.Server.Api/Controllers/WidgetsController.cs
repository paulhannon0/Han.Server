using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Han.Server.Api.Models.Widgets;
using Han.Server.Business.Queries.Widgets.GetWidget;
using Han.Server.Business.Commands.Widgets.CreateWidget;

namespace Han.Server.Api.Controllers
{
    [ApiController]
    public class WidgetsController : ControllerBase
    {
        private readonly ILogger<WidgetsController> logger;
        private readonly ICreateWidgetCommand createWidgetCommand;
        private readonly IGetWidgetQuery getWidgetQuery;

        public WidgetsController(
            ILogger<WidgetsController> logger,
            ICreateWidgetCommand createWidgetCommand,
            IGetWidgetQuery getWidgetQuery
        )
        {
            this.logger = logger;
            this.createWidgetCommand = createWidgetCommand;
            this.getWidgetQuery = getWidgetQuery;
        }

        [HttpPost("/widgets")]
        [Consumes("application/json")]
        public async Task<IActionResult> Create(CreateWidgetRequestModel requestModel)
        {
            var commandRequest = requestModel.ToCommandRequest();
            var commandResponse = await this.createWidgetCommand.ExecuteAsync(commandRequest);

            return Created($"/widgets/{commandResponse}", commandResponse);
        }

        [HttpGet("/widgets/{Id}")]
        [Produces("application/json")]
        public async Task<ActionResult<GetWidgetResponseModel>> Get([FromRoute] ulong id)
        {
            var queryRequest = new GetWidgetQueryRequestModel { Id = id };
            var queryResponse = await this.getWidgetQuery.ExecuteAsync(queryRequest);

            return GetWidgetResponseModel.FromBusinessModel(queryResponse);
        }
    }
}
