using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(10)]
        
        public char IdOrder  { get; set; }
        [Required]
        public DateTime Orderdate { get; set; } = DateTime.Now;

        public int? IdCustomer { get; set; }
        [ForeignKey("IdCustomer")]
        public Customer Customer { get; set; }
        [Range(0, (double)decimal.MaxValue)]
        public decimal Total_Money { get; set; }
        public string Notes { get; set; }
        [ MaxLength(250)]
        public string Name_Reciver { get; set; }
        [ MaxLength(500)]
        public string Address { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [ MaxLength(50)]
        public string Phone { get; set; }
        [DefaultValue(0)]
        public byte IsDelete { get; set; }
        [DefaultValue(1)]
        public byte IsAction { get; set; }
    }
}
