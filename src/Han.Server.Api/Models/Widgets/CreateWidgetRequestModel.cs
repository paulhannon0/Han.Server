using Han.Server.Business.Commands.Widgets.CreateWidget;

namespace Han.Server.Api.Models.Widgets
{
    public class CreateWidgetRequestModel
    {
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
