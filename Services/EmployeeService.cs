using System;
using ORG.Models;

namespace ORG.Services
{
    public class EmployeeService
    {
        private FileService fileService = new FileService();

        // Fixed capacity array to prevent memory overhead
        private Employee[] employees = new Employee[100];
        private int count = 0;

        public EmployeeService()
        {
            // Load existing data from file
            var loaded = fileService.LoadEmployees();

            if (loaded != null)
            {
                // Transfer elements one by one to maintain the 100-slot capacity
                for (int i = 0; i < loaded.Length && count < employees.Length; i++)
                {
                    if (loaded[i] != null)
                    {
                        employees[count] = loaded[i];
                        count++;
                    }
                }
            }
        }

        // ✅ Add Employee
        public void AddEmployee(Employee emp)
        {
            if (emp == null)
                throw new Exception("Invalid Employee");

            // Guard against array overflow[cite: 1]
            if (count >= employees.Length)
                throw new Exception("Array is full! Cannot add more employees.");

            // Prevent duplicate IDs[cite: 1]
            for (int i = 0; i < count; i++)
            {
                if (employees[i] != null && employees[i].Id == emp.Id)
                    throw new Exception("ID already exists!");
            }

            employees[count] = emp;
            count++;

            // Save only the actual data (no nulls)[cite: 1, 2]
            fileService.SaveEmployees(GetAllEmployees());
        }

        // ✅ Update Employee
        public void UpdateEmployee(int id, string name, double salary)
        {
            bool found = false;

            for (int i = 0; i < count; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employees[i].Name = name;
                    employees[i].Salary = salary;
                    found = true;
                    break;
                }
            }

            if (!found)
                throw new Exception("Employee not found!");

            fileService.SaveEmployees(GetAllEmployees());
        }

        // ✅ Delete Employee
        public void DeleteEmployee(int id)
        {
            int index = -1;

            for (int i = 0; i < count; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                throw new Exception("Employee not found!");

            // Shift elements to fill the gap[cite: 1]
            for (int i = index; i < count - 1; i++)
            {
                employees[i] = employees[i + 1];
            }

            // Clean up last element and decrement count[cite: 1]
            employees[count - 1] = null;
            count--;

            fileService.SaveEmployees(GetAllEmployees());
        }

        // ✅ Return current count for Dashboard[cite: 7]
        public int ReturnCount()
        {
            return count;
        }

        // ✅ Return clean array without null slots for UI and Saving[cite: 1, 8]
        public Employee[] GetAllEmployees()
        {
            Employee[] result = new Employee[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = employees[i];
            }

            return result;
        }
    }
}