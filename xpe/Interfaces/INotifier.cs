using xpe.Notifications;

namespace xpe.Interfaces;

public interface INotifier
{
    bool HasNotification();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
    void Handle(string message);
}