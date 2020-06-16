using Han.Server.Business.Models.Widgets.UpdateWidget;
using Microsoft.AspNetCore.Mvc;

namespace Han.Server.Api.Models.Widgets.UpdateWidget
{
    public class UpdateWidgetRequestModel
    {
        [FromRoute]
        public ulong Id { get; set; }

        public string Name { get; set; }

        public UpdateWidgetCommandRequestModel ToCommandRequest()
        {
            return new UpdateWidgetCommandRequestModel
            {
                Id = this.Id,
                Name = this.Name
            };
        }
    }
}
