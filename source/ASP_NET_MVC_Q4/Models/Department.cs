using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC_Q4.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<Department> DepartmentList { get; set; }
    }

    public class Subdepartment
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<Subdepartment > SubdepartmentList { get; set; }
    }
}