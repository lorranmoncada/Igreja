using Igreja.Core.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.NotificationMessage
{
    public class DomainNotificationHandler
    {
        public static IList<DomainNotification> _notifications { get; set; }

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public static void AddNotification(DomainNotification notification)
        {
            if (_notifications == null)
            {
               new DomainNotificationHandler();
            }
            _notifications.Add(notification);
        }

        public bool TemNotificacao()
        {
            return _notifications.Any();
        }

        public IList<string> ListaErros()
        {
            return _notifications.Select(e => e.Message).ToList();
        }

        public void LimparNotification()
        {
            _notifications.Clear();
        }
    }
}
