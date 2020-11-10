﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Business.Model.Output
{
    public class CustomerOutputModel
    {
        public int? Id { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
