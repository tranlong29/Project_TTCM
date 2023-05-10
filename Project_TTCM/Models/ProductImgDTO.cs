using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Project_TTCM.Models
{
    public class ProductImgDTO
    {
        public string Name { get; set; }
        public int IdProduct { get; set; }
    }
}
