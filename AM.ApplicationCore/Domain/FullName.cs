﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned] // entity without a primary key
    public class FullName
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        
    }
    

}
