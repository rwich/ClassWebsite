﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassWebsite.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StockKeepingUnit { get; set; }
        public int Quantity { get; set; }
        [Range(0, double.MaxValue)]
        public double RetailPrice { get; set; }
        [Range(0, 1000000000)]
        public double WholeSalePrice { get; set; }

        public string PhotoLocation { get; set; }
    }
}