﻿using System.ComponentModel.DataAnnotations;

namespace ShoppingAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public ICollection<Product>? Products { get; set; }
    }
}
