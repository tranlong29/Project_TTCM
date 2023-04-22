using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Models
{
    public class ProductConfgDTO
    {
        public int IdProduct { get; set; }
        public int IdConfig { get; set; }
        public string Value { get; set; }
    }
}
