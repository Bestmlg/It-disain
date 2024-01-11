using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace It_disain.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; init; }
        public string Name { get; init; }
        public string Position { get; init; }
        public string Department { get; init; }
        public string ContactDetails { get; init; }
        // Seosed teiste klassidega vastavalt vajadusele
    }
}