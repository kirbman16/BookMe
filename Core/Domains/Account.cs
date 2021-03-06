﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public class Account : BaseEntity
    {
        public virtual string Username { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }


        public virtual ICollection<Performer> Performers { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
