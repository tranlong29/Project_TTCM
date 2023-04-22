using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Product_Config
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public tblProduct Product { get; set; }
        public int IdConfig { get; set; }
        [ForeignKey("IdConfig")]
        public Configuration Configuration { get; set; }
        public string Value { get; set; }
    }
}
