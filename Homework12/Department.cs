using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public class Department
    {
        static int id;
        public List<Worker> Workers { get; private set; } = new List<Worker>();
        public List<Department> SubDepartments { get; private set; } = new List<Department>();
        public string Name { get; private set; }
        public int Id { get; private set; }

        static Department() { id = 0; }
        public Department(string name)
        {
            Name = name;
            Id = id++;
        }
        public void AddWorker(Worker worker)
        {
            Workers.Add(worker);
        }
        public void AddDepartment(Department department)
        {
            SubDepartments.Add(department);
        } 
        public void AddDepartment(string name)
        {
            SubDepartments.Add(new Department(name));
        }
        /// <summary>
        /// Prepares collection of workers for appointment a new manager.
        /// It downgrades currient manager to staff worker.
        /// </summary>
        public void UpdateManager()
        {
            foreach (var worker in Workers)
            {
                if (worker.Manager)
                {
                    worker.MoveToStaff();
                }
            }
        }
    }
}
