using Project_TTCM.Datas;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Project_TTCM.Models
{
    public class OrderDTO
    {
        public char IdOrder { get; set; }
        public DateTime Orderdate { get; set; } = DateTime.Now;
        public int? IdCustomer { get; set; }
        public decimal Total_Money { get; set; }
        public string Notes { get; set; }
        public string Name_Reciver { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte IsDelete { get; set; } = 0;
        public byte IsAction { get; set; } = 1;
    }
}
