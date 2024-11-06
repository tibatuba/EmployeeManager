using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final2_TibaAljaqobi.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
    }
}
