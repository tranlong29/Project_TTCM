using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Orders
    {
        public int Id { get; set; }
        [MaxLength(10)]
        
        public char IdOrder  { get; set; }
        [Required]
        public DateTime Order { get; set; } = DateTime.Now;

        public int? IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Total_Money { get; set; }
        public string Notes { get; set; }
        [Required, MaxLength(250)]
        public string Name_Reciver { get; set; }
        [Required, MaxLength(500)]
        public string Address { get; set; }
        [Required, MaxLength(150)]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        public byte IsDelete { get; set; } = 0;
        public byte IsAction { get; set; } = 1;
    }
}
