using Han.Server.Business.Commands.Widgets.CreateWidget;
using Microsoft.AspNetCore.Mvc;

namespace Han.Server.Api.Models.Widgets
{
    public class CreateWidgetRequestModel
    {
        [FromBody]
        public string Name { get; set; }

        public CreateWidgetCommandRequestModel ToCommandRequest()
        {
            return new CreateWidgetCommandRequestModel
            {
                Name = this.Name
            };
        }
    }
}
