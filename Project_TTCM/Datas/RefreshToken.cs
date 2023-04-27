using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_TTCM.Datas
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        public int IdUser { get; set; }
        [ForeignKey(nameof(IdUser))]
        public Customer customer { get; set; }

        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsActive { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
