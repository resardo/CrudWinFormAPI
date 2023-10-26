using System;
using System.Collections.Generic;

namespace Entities.Model;

public partial class Role
{
    public Guid RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();
}
