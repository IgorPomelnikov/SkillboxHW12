using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_12
{
    public class SalaryCalculator
    {
        public static int CalculateSalary(Positions position, Department department)
        {
            switch (position)
            {
                case Positions.Staff: return 1000;
                case Positions.Intern: return 1000;
                case Positions.Manager: return CalculateManagerSalary(department);
                case Positions.Boss: return 5000;
                default: return 0;
            }
        }

        public static int CalculateManagerSalary(Department department)
        {
            int overallSalary = 0;
            foreach (var worker in department.Workers)
            {
                overallSalary += worker.Salary;
            }
            int managerSalary = overallSalary / 100 * 15;

            if (managerSalary < 1300)
            {
                return 1300;
            }
            else return managerSalary;
        }

    }
}
