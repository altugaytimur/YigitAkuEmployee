﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YigitAkuEmployee.Dtos.EmployeeCrudDtos
{
    public class EmployeeCreateDto:EmployeeBaseDto
    {
        public Guid Id { get; set; }
    }
}
