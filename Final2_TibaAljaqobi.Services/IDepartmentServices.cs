using Final2_TibaAljaqobi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final2_TibaAljaqobi.Services
{
    public interface IDepartmentServices
    {
        public IEnumerable<Department> ListDepartment();
    }
}
