using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.EmployeeDTO
{
    public class EmployeeDTO
    {
        public Guid EmployeeId { get; set; }
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
        public List<Guid> RoleId { get; set; }

    }
}
