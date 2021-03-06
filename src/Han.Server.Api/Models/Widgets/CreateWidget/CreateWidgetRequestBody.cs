using Han.Server.Business.Models.Widgets.CreateWidget;

namespace Han.Server.Api.Models.Widgets.CreateWidget
{
    public class CreateWidgetRequestBody
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
