using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public enum SortCriterion
    {
        Position,
        Salary,
        Name,
    }
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

        public static IComparer<Worker> SortedBy(SortCriterion sortCriterion)
        {
            switch (sortCriterion)
            {
                case SortCriterion.Position:
                    return new SortByPosition();
                case SortCriterion.Salary:
                    return new SortBySalary();
                case SortCriterion.Name:
                    return new SortByName();
                default:
                    return null;
            }
        }

        private class SortByPosition : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                return String.Compare(X.Position.ToString("G"), Y.Position.ToString("G"));
            }
        }

        private class SortBySalary : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                if (X.Salary > Y.Salary) return 1;
                else if (X.Salary == Y.Salary) return 0;
                else return -1;
            }
        }

        private class SortByName : IComparer<Worker>
        {
            public int Compare(Worker x, Worker y)
            {
                Worker X = (Worker)x;
                Worker Y = (Worker)y;

                return String.Compare(X.Name, Y.Name);
            }
        }
    }
}
