using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.Communication
{
    public class DomainNotification
    {
        public string Message { get; private set; }
        public string Key { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid Id { get; private set; }

        public DomainNotification(string key, string value)
        {
            Message = value;
            Key = key;
            TimeStamp = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
