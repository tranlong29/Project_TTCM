using System;
using System.ComponentModel.DataAnnotations;

namespace Project_TTCM.Datas
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        [Required,MaxLength(150)] 
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Phone { get; set; }
        [Required, MaxLength(150)]
        public string Address { get; set; }
        public DateTime Created_Date  { get; set; }
        public byte IsDelete { get; set; } = 0;
        public byte IsAction { get; set; } = 1;




    }
}
