using ORG.Models;
using ORG.Services;
using System;

namespace ORG.Services
{
    public class ProjectService
    {
        private FileService fileService = new FileService();

        // Fixed capacity to maintain array size regardless of file content[cite: 4]
        private Project[] projects = new Project[100];
        private int count = 0;

        public ProjectService()
        {
            // Load projects safely from the storage[cite: 4, 2]
            var loaded = fileService.LoadProjects();

            if (loaded != null)
            {
                // Reset count and transfer projects individually[cite: 4]
                count = 0;
                for (int i = 0; i < loaded.Length && i < projects.Length; i++)
                {
                    if (loaded[i] != null)
                    {
                        projects[count] = loaded[i];
                        count++;
                    }
                }
            }
        }

        // ✅ Add Project
        public void AddProject(Project project)
        {
            if (project == null) return;

            // Prevent array overflow[cite: 1, 4]
            if (count >= projects.Length)
                throw new Exception("Project storage is full!");

            projects[count++] = project;

            // Save only valid entries to JSON[cite: 4, 2]
            fileService.SaveProjects(GetAllProjects());
        }

        // ✅ Update Project
        public void UpdateProject(int id, Project updatedProject)
        {
            for (int i = 0; i < count; i++)
            {
                if (projects[i].Id == id)
                {
                    projects[i].Title = updatedProject.Title;
                    projects[i].Tasks = updatedProject.Tasks;

                    fileService.SaveProjects(GetAllProjects());
                    return;
                }
            }
        }

        // ✅ Delete Project
        public void DeleteProject(int id)
        {
            int index = -1;
            for (int i = 0; i < count; i++)
            {
                if (projects[i].Id == id)
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                // Shift elements to the left[cite: 4]
                for (int i = index; i < count - 1; i++)
                {
                    projects[i] = projects[i + 1];
                }
                projects[--count] = null;
                fileService.SaveProjects(GetAllProjects());
            }
        }

        // ✅ Current Count for Dashboard[cite: 7, 4]
        public int ReturnCount() => count;

        // ✅ Returns a clean array for UI display and JSON saving[cite: 4, 11]
        public Project[] GetAllProjects()
        {
            Project[] result = new Project[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = projects[i];
            }
            return result;
        }
    }
}