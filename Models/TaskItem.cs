using System;
using System.Collections.Generic;
using System.Text;

namespace ORG.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public Employee AssignedEmployee { get; set; }

        public TaskItem(int id, string title)
        {
            Id = id;
            Title = title;
            Status = TaskStatus.Pending;
        }

        public virtual string GetInfo()
        {
            string empName = AssignedEmployee != null ? AssignedEmployee.Name : "Unassigned";
            return $"Task ID: {Id}, Title: {Title}, Status: {Status}, Employee: {empName}";
        }
    }
}