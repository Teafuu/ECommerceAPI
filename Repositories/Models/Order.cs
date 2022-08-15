﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}