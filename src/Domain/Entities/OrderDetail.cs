﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Order Order { get; set; } = new Order();
        public Product Product { get; set; } = new Product();
        public int Quantity { get; set; }
        public decimal Total { get; set; }

    }
}
