using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public class Worker
    {
        static int id;
        public string Name { get; private set; }
        public Positions Position { get; private set; }
        public int Salary { get; private set; }
        public bool Manager { get; private set; }
        public int Id { get; private set; }

        static Worker() { id = 0; }
        public Worker(string name, Positions position, Department department)
        {
            Name = name;
            if (position == Positions.Manager)
            {
                MoveToManager(department);
            }
            else Position = position;
            Salary = SalaryCalculator.CalculateSalary(position, department);
            Id = id++;
            
        }
        
        public void MoveToStaff()
        {
            Manager = false;
            Position = Positions.Staff;
        }

        public void MoveToManager(Department department)
        {
            department.UpdateManager();
            Manager = true;
            Position = Positions.Manager;
        }
    }
}
