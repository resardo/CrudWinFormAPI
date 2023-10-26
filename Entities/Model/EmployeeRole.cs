using System;
using System.Collections.Generic;

namespace Entities.Model;

public partial class EmployeeRole
{
    public int EmployeeRoleId { get; set; }

    public Guid? EmployeeId { get; set; }

    public Guid? RoleId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role? Role { get; set; }
}
