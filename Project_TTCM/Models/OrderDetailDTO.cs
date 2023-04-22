using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Models
{
    public class OrderDetailDTO
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Total { get; set; }
        public int Return_Qty { get; set; }
    }
}
