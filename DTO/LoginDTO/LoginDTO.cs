using DTO.RoleDTO;


namespace DTO.LoginDTO
{
    public class LoginDTO { 
    
        public Guid EmployeeId { get; set; }
        public string Username { get; set; } = null!;
        public List<EmployeeRoleDTO> EmployeeRoles { get; set; }


    }
    public class EmployeeRoleDTO
    {

        public Guid? EmployeeId { get; set; }
        public Guid? RoleId { get; set; }
        
        public RoleDTO1 Role { get; set; }

    }
  


}