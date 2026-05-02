using System;
using System.IO;
using System.Text.Json;
using ORG.Models;

namespace ORG.Services
{
    public class FileService
    {
        private readonly string employeesFile = "employees.json";
        private readonly string tasksFile = "tasks.json";
        private readonly string projectsFile = "projects.json";

        // ✅ حفظ الموظفين (بدون نول)
        public void SaveEmployees(Employee[] employees)
        {
            try
            {
                // نضمن إننا بنسجل البيانات الفعلية فقط
                string json = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(employeesFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Saving Employees: " + ex.Message);
            }
        }

        public Employee[] LoadEmployees()
        {
            try
            {
                if (!File.Exists(employeesFile)) return new Employee[0];
                string json = File.ReadAllText(employeesFile);
                // إذا كان الملف فارغاً نرجع مصفوفة طولها 0 بدل null
                return JsonSerializer.Deserialize<Employee[]>(json) ?? new Employee[0];
            }
            catch { return new Employee[0]; }
        }

        // ✅ حفظ المهام
        public void SaveTasks(TaskItem[] tasks)
        {
            try
            {
                string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(tasksFile, json);
            }
            catch (Exception ex) { Console.WriteLine("Error Saving Tasks: " + ex.Message); }
        }

        public TaskItem[] LoadTasks()
        {
            try
            {
                if (!File.Exists(tasksFile)) return new TaskItem[0];
                string json = File.ReadAllText(tasksFile);
                return JsonSerializer.Deserialize<TaskItem[]>(json) ?? new TaskItem[0];
            }
            catch { return new TaskItem[0]; }
        }

        // ✅ حفظ المشاريع
        public void SaveProjects(Project[] projects)
        {
            try
            {
                string json = JsonSerializer.Serialize(projects, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(projectsFile, json);
            }
            catch (Exception ex) { Console.WriteLine("Error Saving Projects: " + ex.Message); }
        }

        public Project[] LoadProjects()
        {
            try
            {
                if (!File.Exists(projectsFile)) return new Project[0];
                string json = File.ReadAllText(projectsFile);
                return JsonSerializer.Deserialize<Project[]>(json) ?? new Project[0];
            }
            catch { return new Project[0]; }
        }
    }
}