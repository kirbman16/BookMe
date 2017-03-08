using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class EventNeed : BaseEntity
    {
        public virtual int EventId { get; set; }
        public virtual Event Event { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual int Quantity { get; set; }
    }
}
