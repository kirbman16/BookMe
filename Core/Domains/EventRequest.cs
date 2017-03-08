using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class EventRequest : BaseEntity
    {
        public virtual int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual int PerformerId { get; set; }
        public virtual Performer Performer { get; set; }

        public virtual RequestStatus Status { get; set; }
        public virtual string Details { get; set; }

        public virtual ICollection<EventRequestNegotiation> Negotiations { get; set; }
    }
}
