using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final2_TibaAljaqobi.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime JoiningDate { get; set; }
        public int? DependentCount { get; set; }
        public double? Salary { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
