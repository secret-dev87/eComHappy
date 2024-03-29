﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token : BaseEntity<int>, IAggregateRoot
    {

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public string EndTimeRefreshToken { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
