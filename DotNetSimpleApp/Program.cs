using System;
using System.Collections.Generic;

class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public void Display()
    {
        Console.WriteLine($"[{(IsCompleted ? "✔" : " ")}] Task ID: {Id}, Description: {Description}");
    }
}

class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    public void AddTask(string description)
    {
        tasks.Add(new Task
        {
            Id = nextId++,
            Description = description,
            IsCompleted = false
        });
        Console.WriteLine("Task added successfully.\n");
    }

    public void DisplayTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.\n");
            return;
        }

        Console.WriteLine("\nTasks:");
        foreach (var task in tasks)
        {
            task.Display();
        }
    }

    public void CompleteTask(int id)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            Console.WriteLine($"Task {id} marked as completed.\n");
        }
        else
        {
            Console.WriteLine($"Task with ID {id} not found.\n");
        }
    }

    public void DeleteTask(int id)
    {
        Task task = tasks.Find(t => t.Id == id);
        if (task != null)
        {
            tasks.Remove(task);
            Console.WriteLine($"Task {id} deleted.\n");
        }
        else
        {
            Console.WriteLine($"Task with ID {id} not found.\n");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nTask Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Display Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: \n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    taskManager.AddTask(description);
                    break;

                case "2":
                    taskManager.DisplayTasks();
                    break;

                case "3":
                    Console.Write("Enter Task ID to mark as completed: ");
                    if (int.TryParse(Console.ReadLine(), out int completeId))
                    {
                        taskManager.CompleteTask(completeId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Task ID.\n");
                    }
                    break;

                case "4":
                    Console.Write("Enter Task ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        taskManager.DeleteTask(deleteId);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid Task ID.\n");
                    }
                    break;

                case "5":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }

        Console.WriteLine("Thank you for using Task Manager!\n");
    }
}
