using ORG.Models;
using System.Collections.Generic;
using ORG.Services;
using TaskStatus = ORG.Models.TaskStatus;

namespace ORG.Services
{
    public class TaskService
    {
        private FileService fileService = new FileService();

        // Fixed capacity to ensure consistent array size
        private TaskItem[] tasks = new TaskItem[100];
        private int count = 0;

        public TaskService()
        {
            // Load existing tasks from the JSON file
            var loadedTasks = fileService.LoadTasks();

            if (loadedTasks != null)
            {
                // Reset count and transfer elements without breaking the 100-size limit
                count = 0;
                for (int i = 0; i < loadedTasks.Length && i < tasks.Length; i++)
                {
                    if (loadedTasks[i] != null)
                    {
                        tasks[count] = loadedTasks[i];
                        count++;
                    }
                }
            }
        }

        // ✅ Add Task
        public void AddTask(TaskItem task)
        {
            if (task == null) return;

            // Check for duplicate IDs
            for (int i = 0; i < count; i++)
            {
                if (tasks[i].Id == task.Id) return;
            }

            // Guard against index out of range[cite: 5]
            if (count < tasks.Length)
            {
                tasks[count++] = task;
                // Save only the active elements to file[cite: 5, 2]
                fileService.SaveTasks(GetAllTasks());
            }
            else
            {
                throw new System.Exception("Task array is full!");
            }
        }

        // ✅ Update Task
        public void UpdateTask(int id, TaskItem updatedTask)
        {
            for (int i = 0; i < count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks[i].Title = updatedTask.Title;
                    tasks[i].Status = updatedTask.Status;
                    tasks[i].AssignedEmployee = updatedTask.AssignedEmployee;

                    fileService.SaveTasks(GetAllTasks());
                    return;
                }
            }
        }

        // ✅ Delete Task
        public void DeleteTask(int id)
        {
            for (int i = 0; i < count; i++)
            {
                if (tasks[i].Id == id)
                {
                    // Shift elements to the left to maintain array integrity[cite: 5]
                    for (int j = i; j < count - 1; j++)
                    {
                        tasks[j] = tasks[j + 1];
                    }
                    tasks[--count] = null;
                    fileService.SaveTasks(GetAllTasks());
                    return;
                }
            }
        }

        // ✅ Return clean array for UI and GridView[cite: 5, 6]
        public TaskItem[] GetAllTasks()
        {
            TaskItem[] result = new TaskItem[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = tasks[i];
            }
            return result;
        }

        public int ReturnCount() => count;

        public int ReturnCountDone()
        {
            int doneCount = 0;
            for (int i = 0; i < count; i++)
            {
                if (tasks[i] != null && tasks[i].Status == TaskStatus.Done)
                {
                    doneCount++;
                }
            }
            return doneCount;
        }
    }
}