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
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string ContactDetails { get; set; }
        // Seosed teiste klassidega vastavalt vajadusele
    }
}