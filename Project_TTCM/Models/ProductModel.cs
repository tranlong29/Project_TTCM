using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Project_TTCM.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile fileImages { get; set; }
        public string Notes { get; set; }
        public int? IdCategory { get; set; }
        public decimal Price { get; set; }

        public int Quatity { get; set; }

        
        public byte ISDELETE { get; set; }
        public byte ISACTIVE { get; set; }

    }
}
