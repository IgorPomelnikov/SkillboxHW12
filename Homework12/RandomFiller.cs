using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    public class RandomFiller : ILoader
    {
        static Random random = new Random();

        public Company Get()
        {
            return Generate();
        }

        /// <summary>
        /// Generates a company with departments and workers
        /// </summary>
        /// <returns>Department with data</returns>
        private static Company Generate()
        {
            Department baseDepartment = new Department("Company");

            int countOfDeps = random.Next(1, 11);
            int avaliableDepth = random.Next(10);
            int maxWorkers = random.Next(1, 501);

            CreateFirstDepatmentLayer(baseDepartment, countOfDeps); //Creating first layer of deparment, basic strucure
            CreateDeepDepStucture(baseDepartment, avaliableDepth); //Expanding sructure in random deep in each department
            FillWorkers(baseDepartment.SubDepartments, maxWorkers); //Filling up all departpments with random count of workers
            AppointManagers(baseDepartment); //Appoint random worker as manager of department

            return new Company(baseDepartment);
        } 
        private static void CreateDeepDepStucture(Department department, int avaliableDepth)
        {
            foreach (var dep in department.SubDepartments)
            {
                CreateDepartment(random.Next(1, avaliableDepth), 1, dep);
            }
        }
        private static void CreateFirstDepatmentLayer(Department department, int countOfDeps)
        {
            department.AddDepartment("Fired");
            
            for (int i = 1; i < countOfDeps + 1; i++)
            {
                CreateDepartment(department, i);
            }
        }
        private static Department CreateDepartment(Department department, int i)
        {
            department.AddDepartment($"Department_{i}");
            return department.SubDepartments[i - 1];
        }
        private static Department CreateDepartment(int stop, int depth, Department dep)
        {
            int randomNumber = random.Next(1, 5);
            for (int i = 1; i < randomNumber; i++)
            {
                dep.AddDepartment($"{dep.Name}{i}");
            }

            depth++;

            if (depth < stop)
            {
                foreach (var item in dep.SubDepartments)
                {
                    CreateDepartment(stop, depth, item);
                }
            }
            return dep;
        }
        private static void FillWorkers(List<Department> departments, int maxWorkers)
        {
            foreach (var department in departments)
            {
                int countOfWorkers = random.Next(maxWorkers + 1);

                for (int i = 0; i < countOfWorkers; i++)
                {
                    switch (random.Next(2))
                    {
                        case 0: department.AddWorker(AddIntern(department, i)); break;
                        case 1: department.AddWorker(AddStuff(department, i)); break;
                        default:
                            break;
                    }
                }
                FillWorkers(department.SubDepartments, maxWorkers);
            }
        }
        private static Worker AddIntern(Department department, int i)
        {
            return new Worker($"Dep.{department.Id}_Worker_{i}", Positions.Intern, department);
        }
        private static Worker AddStuff(Department department, int i)
        {
            return new Worker($"Dep.{department.Id}_Worker_{i}", Positions.Staff, department);
        }
        private static void AppointManagers(Department department)
        {
            if (department.SubDepartments is not null)
            {
                foreach (var dep in department.SubDepartments)
                {
                    AppointManagers(dep);
                }
            }
            if (department.Workers is not null && department.Workers.Count > 0)
            {
                department.Workers[random.Next(department.Workers.Count)].MoveToManager(department);
            }
            else if(department.Workers is not null) department.Workers[0].MoveToManager(department);

        }

       
    }
}

