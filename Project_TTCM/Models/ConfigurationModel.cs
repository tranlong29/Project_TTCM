using System.ComponentModel.DataAnnotations;
using System;

namespace Project_TTCM.Models
{
    public class ConfigurationModel
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public byte ISDELETE { get; set; } = 0;
        public byte ISACTIVE { get; set; } = 1;
    }
}
