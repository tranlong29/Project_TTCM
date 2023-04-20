using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Product_Config
    {
        [Key]
        public Guid Id { get; set; }
        public Guid IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public tblProduct Product { get; set; }
        public Guid IdConfig { get; set; }
        [ForeignKey("IdConfig")]
        public Configuration Configuration { get; set; }
        public string Value { get; set; }
    }
}
