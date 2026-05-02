using System;
using System.Collections.Generic;
using System.Text;

namespace ORG.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskItem[] Tasks { get; set; } = new TaskItem[0];
        public int TasksCount
        {
            get { return Tasks != null ? Tasks.Length : 0; }
        }
    }
}