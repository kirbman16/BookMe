using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Category : BaseEntity
    {
        public virtual string Name { get; set; }

        public virtual ICollection<Performer> Performers { get; set; }
        public virtual ICollection<EventNeed> Needed { get; set; }
    }
}
