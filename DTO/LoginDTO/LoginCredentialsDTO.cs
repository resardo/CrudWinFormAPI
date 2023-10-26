﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.UserDTO
{
    public class LoginCredentialsDTO
    {
        
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
