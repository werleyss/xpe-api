using xpe.Interfaces;

namespace xpe.Notifications;

public class Notifier : INotifier
{
    private List<Notification> _notifications;
    
    public Notifier()
    {
        _notifications = new List<Notification>(0);
    }
    
    public bool HasNotification()
    {
        return _notifications.Any();
    }

    public List<Notification> GetNotifications()
    {
        return _notifications;
    }

    public void Handle(Notification notification)
    {
        _notifications.Add(notification);
    }

    public void Handle(string message)
    {
        Handle(new Notification(message));
    }
}