using System;

namespace Han.Server.Api.Models.Widgets
{
    public class GetWidgetResponseModel
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public static GetWidgetResponseModel FromBusinessModel(Han.Server.Business.Models.Widget widget)
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
