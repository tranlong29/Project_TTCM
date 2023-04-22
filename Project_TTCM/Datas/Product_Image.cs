using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Datas
{
    public class Product_Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URLIMG { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public tblProduct Product { get; set; }
    }
}
