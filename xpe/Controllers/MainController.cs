using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using xpe.Interfaces;
using xpe.Notifications;

namespace xpe.Controllers;

public class MainController : ControllerBase
{
    protected readonly INotifier _notifier;

    public MainController(INotifier notifier)
    {
        _notifier = notifier;
    }

    protected bool IsValid()
    {
        return !_notifier.HasNotification();
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsValid())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        return BadRequest(new
        {
            success = false,
            errors = _notifier.GetNotifications().Select(n => n.Message)
        });
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        return CustomResponse();
    }

    protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(v => v.Errors);

        foreach (var error in errors)
        {
            var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
            NotityError(errorMsg);
        }
    }

    protected void NotityError(string message)
    {
        _notifier.Handle(new Notification(message));
    }
}