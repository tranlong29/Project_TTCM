using System;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Datas
{
    public class Category
    {
        [Key]
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
        public byte ISDELETE { get; set; } = 0;
        public byte ISACTIVE { get; set; } = 1;

    }
}
