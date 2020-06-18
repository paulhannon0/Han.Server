using Han.Server.Business.Models.Widgets.DeleteWidget;

namespace Han.Server.Business.Commands.Widgets.DeleteWidget
{
    public interface IDeleteWidgetCommand : ICommand<DeleteWidgetCommandRequestModel, ulong> { }
}
