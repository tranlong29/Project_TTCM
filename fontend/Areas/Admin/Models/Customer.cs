using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace fontend.Areas.Admin.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public byte IsDelete { get; set; }
        public byte IsAction { get; set; }
        public byte Admin { get; set; }
    }
}
