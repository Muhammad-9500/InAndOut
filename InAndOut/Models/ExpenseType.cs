﻿using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class ExpenseType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
