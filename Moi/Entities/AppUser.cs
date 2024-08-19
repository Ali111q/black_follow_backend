using System.ComponentModel.DataAnnotations;
using BackEndStructuer.Entities;
using GaragesStructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace GaragesStructure.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public Guid? RoleId { get; set; }
        public Role? Role { get; set; }
        public decimal Balance { get; set; } = 0;
        public AccountType Account { get; set; } = AccountType.STANDARD;
        
        public bool? IsActive { get; set; } = true;
        public List<Order> Orders { get; set; } 



        

        

    }
    
}