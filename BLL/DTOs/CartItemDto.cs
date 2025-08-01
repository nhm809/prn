﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartItemDto
    {
        public int CartItemId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;


    }

}
