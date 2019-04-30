using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_Q4_using_Fetch.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Department> departments { get; set; }
    }

    public class SubDepartment
    {
        public int ParentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SubDepartment> subDepartments { get; set; }
    }
}