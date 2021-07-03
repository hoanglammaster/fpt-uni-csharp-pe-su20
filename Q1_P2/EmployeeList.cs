using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Q1_P2
{
    public class EmployeeList
    {
        private List<Employee> listEmployee;

        public EmployeeList()
        {
            listEmployee = new List<Employee>();
        }

        public EmployeeList(List<Employee> employees)
        {
            this.listEmployee = employees;
        }

        public void ReadFromFile(string filename)
        {
            using(StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Employee employee = new Employee();
                    employee.ReadFromString(line);

                    listEmployee.Add(employee);
                }
            }
        }
        public void Display()
        {
            Console.WriteLine("Number Of Employees in the input file: " + listEmployee.Count);
            foreach(Employee employee in listEmployee)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
