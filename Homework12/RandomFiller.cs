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

        public Department Get()
        {
            return Generate();
        }

        /// <summary>
        /// Generates a company with departments and workers
        /// </summary>
        /// <returns>Department with data</returns>
        private static Department Generate()
        {
            Department company = new Department("Company");

            int countOfDeps = random.Next(1, 11);
            int avaliableDepth = random.Next(10);
            int maxWorkers = random.Next(1, 501);

            CreateFirstDepatmentLayer(company, countOfDeps); //Creating first layer of deparment, basic strucure
            CreateDeepDepStucture(company, avaliableDepth); //Expanding sructure in random deep in each department
            FillWorkers(company.SubDepartments, maxWorkers); //Filling up all departpments with random count of workers
            AppointManagers(company); //Appoint random worker as manager of department

            return company;
        } 
        private static void CreateDeepDepStucture(Department company, int avaliableDepth)
        {
            foreach (var dep in company.SubDepartments)
            {
                CreateDepartment(random.Next(1, avaliableDepth), 1, dep);
            }
        }
        private static void CreateFirstDepatmentLayer(Department company, int countOfDeps)
        {
            company.AddDepartment("Fired");
            
            for (int i = 1; i < countOfDeps + 1; i++)
            {
                CreateDepartment(company, i);
            }
        }
        private static Department CreateDepartment(Department dep, int i)
        {
            dep.AddDepartment($"Department_{i}");
            return dep.SubDepartments[i - 1];
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
            foreach (var d in departments)
            {
                int countOfWorkers = random.Next(maxWorkers + 1);

                for (int i = 0; i < countOfWorkers; i++)
                {
                    switch (random.Next(2))
                    {
                        case 0: d.AddWorker(AddIntern(d, i)); break;
                        case 1: d.AddWorker(AddStuff(d, i)); break;
                        default:
                            break;
                    }
                }
                FillWorkers(d.SubDepartments, maxWorkers);
            }
        }
        private static Worker AddIntern(Department dep, int i)
        {
            return new Worker($"Dep.{dep.Id}_Worker_{i}", Positions.Intern, dep);
        }
        private static Worker AddStuff(Department dep, int i)
        {
            return new Worker($"Dep.{dep.Id}_Worker_{i}", Positions.Staff, dep);
        }
        private static void AppointManagers(Department department)
        {
            if (department.SubDepartments != null)
            {
                foreach (var dep in department.SubDepartments)
                {
                    AppointManagers(dep);
                }
            }
            if (department.Workers != null && department.Workers.Count > 0)
            {
                department.Workers[random.Next(department.Workers.Count)].MoveToManager(department);
            }
            else if(department.Workers != null) department.Workers[0].MoveToManager(department);

        }

       
    }
}

