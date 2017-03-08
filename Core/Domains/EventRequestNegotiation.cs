using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class EventRequestNegotiation : BaseEntity
    {
        public virtual double Fee { get; set; }
        public virtual RatePeriod Period { get; set; }
        public virtual bool PerformerAgrees { get; set; }
        public virtual bool OrganizationAgrees { get; set; }
        public virtual DateTime DateSent { get; set; }
        public virtual DateTime? DateAgreed { get; set; }
        public virtual DateTime? CancellationDate { get; set; }

        public virtual int EventRequestId { get; set; }
        public virtual EventRequest EventRequest { get; set; }
    }
}
