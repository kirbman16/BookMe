using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Performer : BaseEntity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string StageName { get; set; }
        
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual bool HidePhoneNumber { get; set; }
        public virtual bool HideEmail { get; set; }


        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual int AccountId { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<EventRequest> Requests { get; set; }
    }
}
