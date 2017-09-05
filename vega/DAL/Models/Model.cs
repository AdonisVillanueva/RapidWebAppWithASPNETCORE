// ======================================
// Author: Adonis Villanueva
// Email:  thedynamiclight@gmail.com
// Copyright (c) 2017 www.alwayswanderlust.com
// 
// ==> Inquiries: thedynamiclight@gmail.com
// ======================================

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Models")]
    public class Model
    {
        [Required]
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int UnitsInStock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDiscontinued { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }


        public int? ParentId { get; set; }
        public Model Parent { get; set; }

        public int MakeId { get; set; }
        public Make Make { get; set; }

        public ICollection<Model> Children { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
