// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DAL.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Required]
        public int Id { get; set; }

        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
