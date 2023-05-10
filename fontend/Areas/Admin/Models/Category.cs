using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace fontend.Areas.Admin.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
