using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Configuration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Notes { get; set; }
        [DefaultValue(0)]
        public byte ISDELETE { get; set; }
        [DefaultValue(1)]
        public byte ISACTIVE { get; set; }
    }
}
