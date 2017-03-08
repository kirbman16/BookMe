using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Rate : BaseEntity
    {
        public virtual string Details { get; set; }
        public virtual double Fee { get; set; }
        public virtual RatePeriod Period { get; set; }
        public virtual RateStatus Status { get; set; }

        public virtual int PerfomerId { get; set; }
        public virtual Performer Performer { get; set; }
    }
}
