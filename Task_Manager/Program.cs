using System;
using System.Linq;
using Task_Manager;
using Task_Manager.TaskManager;


namespace Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Data/tasks.json";

            //var seed = new Seed(filePath);
            //seed.SeedData();

            var manager = new Manager(filePath);

            if (args.Length == 0)
            {
                Console.WriteLine("You Entered no Argument...");
                return;
            }
            string command = args[0].ToLower();


            switch (command)
            {
                case "add":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("You need two arguments to add task");
                        break;
                    }
                    string addDescription = args[1];
                    manager.AddTask(addDescription);
                    Console.WriteLine($"Task added successfully.");
                    break;

                case "update":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("You need to specify a task ID and description.");
                        break;
                    }
                    int updateId = int.Parse(args[1]); 
                    string updateDescription = string.Join(" ", args.Skip(2));
                    manager.UpdateTask(updateId, updateDescription);
                    Console.WriteLine("Task updated successfully.");
                    break;

                case "delete":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("You need to specify a task ID.");
                        break;
                    }
                    int deleteId = int.Parse(args[1]);
                    manager.DeleteTask(deleteId);
                    Console.WriteLine("Task deleted successfully.");
                    break;

                case "mark-in-progress":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("You need to specify a task ID.");
                        break;
                    }
                    int inProgressId = int.Parse(args[1]);
                    manager.MarkInProgress(inProgressId);
                    Console.WriteLine("Task marked as In Progress.");
                    break;

                case "mark-done":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("You need to specify a task ID.");
                        break;
                    }
                    int doneId = int.Parse(args[1]);
                    manager.MarkCompleted(doneId);
                    Console.WriteLine("Task marked as Done.");
                    break;

                case "list":
                    if (args.Length == 1) 
                    {
                        manager.ListAllTasks();
                    }
                    else if (args[1].ToLower() == "done")
                  {
                        manager.ListDone();
                    }
                    else if (args[1].ToLower() == "todo")
                    {
                        manager.ListToDo();
                    }
                    else if (args[1].ToLower() == "in-progress")
                    {
                        manager.ListInProgress();
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid status provided for list.");
                    }
                    break;

                default:
                    Console.WriteLine("Error: Invalid command.");
                 
                    break;
            }
        }


    }
}

