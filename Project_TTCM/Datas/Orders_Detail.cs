using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Orders_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public Orders Orders { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public tblProduct Product { get; set; }
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int Qty { get; set; }
        public decimal Total { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Return_Qty { get; set; }
    }
}
