using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class tblProduct
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        [MaxLength(550)]
        public string Images { get; set; }
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
        [Required]
        [MaxLength(550)]
        public string Content { get; set; }
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Quatity { get; set;}
        [MaxLength(150)]
        public string SLUG { get; set; }
        [Required]
        [MaxLength(100)]
        public string META_TITLE { get; set; }
        [Required]
        [MaxLength(500)]
        public string META_DESCRIPTION { get; set; }
        [Required]
        [MaxLength(500)]
        public string META_KEYWORD { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int CREATED_BY { get; set; }
        public byte ISDELETE { get; set; } = 0;
        public byte ISACTIVE { get; set; } = 1;

    }
}
