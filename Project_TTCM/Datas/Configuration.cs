using System;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Datas
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Notes { get; set; }
        public byte ISDELETE { get; set; } = 0;
        public byte ISACTIVE { get; set; } = 1;
    }
}
