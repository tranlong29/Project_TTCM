using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace fontend.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Images { get; set; }
        public int? IdCategory { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Quatity { get; set; }
        public byte ISDELETE { get; set; }
        public byte ISACTIVE { get; set; }
        public IFormFile fileImages { get; set; }
    }
}
