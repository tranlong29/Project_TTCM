using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class tblProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Notes { get; set; }
        [MaxLength(550)]
        public string Images { get; set; }
        public int? IdCategory { get; set; }
        [ForeignKey("IdCategory")]
        public Category Category { get; set; }
       /* [MaxLength(550)]*/
        /*public string Content { get; set; }*/
        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Quatity { get; set;}
        /*
        [MaxLength(150)]
        public string SLUG { get; set; }
        [MaxLength(100)]
        public string META_TITLE { get; set; }
        [MaxLength(500)]
        public string META_DESCRIPTION { get; set; }
        [MaxLength(500)]
        public string META_KEYWORD { get; set; }*/
        public DateTime CREATED_DATE { get; set; } = DateTime.Now;
        /*public int? CREATED_BY { get; set; }*/
        [DefaultValue(0)]
        public byte? ISDELETE { get; set; }
        public byte? ISACTIVE { get; set; }

        [NotMapped]
        public IFormFile fileImages { get; set; }
    }
}
