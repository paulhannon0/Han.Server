using Microsoft.AspNetCore.Mvc;
using Han.Server.Business.Queries.Widgets.GetWidget;

namespace Han.Server.Api.Models.Widgets
{
    public class GetWidgetRequestModel
    {
        [FromRoute]
        public ulong Id { get; set; }

        public GetWidgetQueryRequestModel ToQueryRequest()
        {
            return new GetWidgetQueryRequestModel
            {
                Id = this.Id
            };
        }
    }
}
