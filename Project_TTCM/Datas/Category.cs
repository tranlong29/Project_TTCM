using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Notes { get; set; }
        [Required]
        [MaxLength(250)]
        public string ICON { get; set; }
        [MaxLength(150)]
        public string SLUG { get; set; }
        [Required]
        [MaxLength(100)]
        public string META_TITLE { get; set; }
        [Required]
        [MaxLength(500)]
        public string META_DESCRIPTION { get; set;}
        [Required]
        [MaxLength(500)]
        public string META_KEYWORD { get; set; }
        public DateTime CREATED_DATE { get; set; }
        public int CREATED_BY { get; set; }
        [DefaultValue(0)]
        public byte ISDELETE { get; set; }
        [DefaultValue(1)]
        public byte ISACTIVE { get; set; }

    }
}
