using System;
using System.Collections.Generic;

namespace TaskTracker
{
    class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }

    class TaskTracker
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public void UpdateTask(int taskId, Task updatedTask)
        {
            Task existingTask = tasks.Find(t => t.TaskId == taskId);
            if (existingTask != null)
            {
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.Priority = updatedTask.Priority;
                existingTask.DueDate = updatedTask.DueDate;
                existingTask.Status = updatedTask.Status;
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        public void DeleteTask(int taskId)
        {
            Task task = tasks.Find(t => t.TaskId == taskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
            else
            {
                Console.WriteLine("Task not found!");
            }
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public List<Task> GetTasksByStatus(string status)
        {
            return tasks.FindAll(t => t.Status == status);
        }

        // Implement additional methods as needed
    }

    class Program
    {
        static void Main(string[] args)
        {
            TaskTracker taskTracker = new TaskTracker();

            // Example usage of task management operations
            Task task1 = new Task
            {
                TaskId = 1,
                Title = "Complete Project",
                Description = "Finish the project before the deadline",
                Priority = 2,
                DueDate = new DateTime(2023, 6, 30),
                Status = "In Progress"
            };
            taskTracker.AddTask(task1);

            Task task2 = new Task
            {
                TaskId = 2,
                Title = "Review Code",
                Description = "Review and provide feedback on code",
                Priority = 1,
                DueDate = new DateTime(2023, 6, 25),
                Status = "Completed"
            };
            taskTracker.AddTask(task2);

            // Get all tasks
            List<Task> allTasks = taskTracker.GetTasks();
            foreach (Task task in allTasks)
            {
                Console.WriteLine($"Task ID: {task.TaskId}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Due Date: {task.DueDate}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine();
            }

            // Update task
            Task updatedTask = new Task
            {
                Title = "Complete Project Phase 1",
                Description = "Finish Phase 1 of the project",
                Priority = 2,
                DueDate = new DateTime(2023, 7, 15),
                Status = "In Progress"
            };
            taskTracker.UpdateTask(1, updatedTask);

            // Delete task
            taskTracker.DeleteTask(2);

            // Get tasks by status
            List<Task> inProgressTasks = taskTracker.GetTasksByStatus("In Progress");
            foreach (Task task in inProgressTasks)
            {
                Console.WriteLine($"Task ID: {task.TaskId}");
                Console.WriteLine($"Title: {task.Title}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Due Date: {task.DueDate}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine();
            }

            // Implement additional functionalities like sorting tasks, searching tasks, etc.

            Console.ReadLine();
        }
    }}
