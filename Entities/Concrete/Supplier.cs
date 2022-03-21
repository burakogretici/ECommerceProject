﻿using System;
using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class Supplier : BaseEntity
    {
        public Guid CustomerId  { get; set; }
        public string CompanyName { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public ICollection<Product> Products { get; set; }
        public Customer Customer { get; set; }

    }
}
