using Han.Server.Business.Models.Widgets.UpdateWidget;

namespace Han.Server.Api.Models.Widgets.UpdateWidget
{
    public class UpdateWidgetRequestBody
    {
        public string Name { get; set; }

        public UpdateWidgetCommandRequestModel ToCommandRequest(ulong id)
        {
            return new UpdateWidgetCommandRequestModel
            {
                Id = id,
                Name = this.Name
            };
        }
    }
}
