using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public class Company
    {
        public Department Department { get; private set; }

        public Company (Department department)
        {
            Department = department;
        }

        public string GetName()
        {
            return Department.Name;
        }
    }
}
