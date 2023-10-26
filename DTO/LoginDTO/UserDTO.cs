using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class EmployeDTO
    {
         public Guid UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string Username { get; set; } = null!;
        //public string LastName { get; set; } = null!;
        ////public DateTime Dob { get; set; }
        //public string Password { get; set; } = null!;
        //public int Status { get; set; }
    }
}
