using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igreja.Core.Messages
{
    public abstract class Message
    {
        public string Messagetype { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            Messagetype = GetType().Name;
        }
    }
}
