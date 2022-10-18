namespace HvZWebAPI.SignalRChat.Notifications;

public class Notification<T> : INotification
{
    public NotificationType Type { get; set; }

    public T Payload { get; set; }


}
