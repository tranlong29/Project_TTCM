using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fontend.Models
{
    public class Product_Images
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URLIMG { get; set; }
        public int IdProduct { get; set; }
    }
}