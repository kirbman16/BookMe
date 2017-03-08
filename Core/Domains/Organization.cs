using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Organization : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Details { get; set; }
        public virtual string ContactName { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual string ContactEmail { get; set; }
        public virtual bool HideContactInfo { get; set; }
        public virtual string City { get; set; }
        public virtual State? State { get; set; }
        public virtual string ZipCode { get; set; }

        public virtual int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
