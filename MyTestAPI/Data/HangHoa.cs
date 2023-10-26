﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTestAPI.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TenHh { get; set; }
        public string MoTa {  get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
    }
}
