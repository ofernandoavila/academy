using Ofernandoavila.Academy.Business.Interfaces.Settings;

namespace Ofernandoavila.Academy.Business.Models.Settings
{
    public class Notificator : INotificator
    {
        private readonly List<Notification> _notifications;
        public Notificator()
        {
            _notifications = [];
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Count != 0;
        }
    }
}
