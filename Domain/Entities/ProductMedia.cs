﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductMedia : BaseEntity<Guid>, IAggregateRoot
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }

        public Guid ProductItemId { get; set; }
        public Guid ProductId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}