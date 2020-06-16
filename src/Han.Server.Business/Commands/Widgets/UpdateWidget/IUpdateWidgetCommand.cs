using Han.Server.Business.Models.Widgets.UpdateWidget;

namespace Han.Server.Business.Commands.Widgets.UpdateWidget
{
    public interface IUpdateWidgetCommand : ICommand<UpdateWidgetCommandRequestModel, ulong> { }
}
