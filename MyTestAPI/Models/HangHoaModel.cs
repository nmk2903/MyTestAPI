using System.ComponentModel.DataAnnotations;

namespace MyTestAPI.Models
{
    public class HangHoaModel
    {
        [Key]
        public int MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string? TenHh { get; set; }
        public string MoTa { get; set; }
        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }
    }
}
