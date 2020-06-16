using System;
using Han.Server.Business.Models.Widgets;

namespace Han.Server.Api.Models.Widgets.GetWidget
{
    public class GetWidgetResponseModel
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public static GetWidgetResponseModel FromBusinessModel(Widget widget)
        {
            return new GetWidgetResponseModel
            {
                Id = widget.Id,
                Name = widget.Name,
                CreatedAt = widget.CreatedAt,
                UpdatedAt = widget.UpdatedAt
            };
        }
    }
}
