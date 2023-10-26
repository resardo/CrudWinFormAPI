using System;
using System.Collections.Generic;

namespace Entities.Model;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    public virtual ICollection<Form> Forms { get; set; } = new List<Form>();
}
