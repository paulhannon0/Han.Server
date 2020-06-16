using Han.Server.Business.Models.Widgets.CreateWidget;

namespace Han.Server.Business.Commands.Widgets.CreateWidget
{
    public interface ICreateWidgetCommand : ICommand<CreateWidgetCommandRequestModel, ulong> { }
}
