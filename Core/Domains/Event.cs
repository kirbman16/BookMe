using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Event : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual State? State { get; set; }
        public virtual string Zip { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual double? Budget { get; set; }
        public virtual EventStatus Status { get; set; }
        public virtual DateTime? CancellationDate { get; set; }

        public virtual int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        public virtual ICollection<EventRequest> Requests { get; set; }
        public virtual ICollection<EventNeed> Needs { get; set; }
    }
}
