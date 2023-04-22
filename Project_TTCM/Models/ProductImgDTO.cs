using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Models
{
    public class ProductImgDTO
    {
        public string Name { get; set; }
        public string URLIMG { get; set; }
        public int IdProduct { get; set; }
    }
}
