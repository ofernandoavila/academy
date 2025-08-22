using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ofernandoavila.Academy.Business.Models.Settings;

namespace Ofernandoavila.Academy.Business.Interfaces.Settings
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);

    }
}
