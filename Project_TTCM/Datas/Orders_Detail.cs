using System;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Datas
{
    public class Orders_Detail
    {
        public Guid Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; } = 0;
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public int Qty { get; set; } = 0;
        public decimal Total { get; set; }
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public int Return_Qty { get; set; } = 0;
    }
}
