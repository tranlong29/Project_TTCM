using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        [ MaxLength(50)]
        public string Phone { get; set; }
        [ MaxLength(150)]
        public string Address { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
        [DefaultValue(0)]
        public byte IsDelete { get; set; }
        [DefaultValue(1)]
        public byte IsAction { get; set; }
        [DefaultValue(0)]
        public byte Admin { get; set;}




    }
}
