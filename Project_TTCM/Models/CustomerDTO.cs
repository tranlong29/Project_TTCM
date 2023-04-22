using System.ComponentModel.DataAnnotations;
using System;

namespace Project_TTCM.Models
{
    public class CustomerDTO
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created_Date { get; set; }
        public byte IsDelete { get; set; }
        public byte IsAction { get; set; }
        public byte Admin { get; set; }
    }
}
