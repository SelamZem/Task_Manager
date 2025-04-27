using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Task_Manager.Models;

namespace Task_Manager
{
    internal class Seed
    {
        private readonly string filePath;

        public Seed(string filePath)
        {
            this.filePath = filePath;
        }

        public void SeedData()
        {
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(existingJson))
                {
                    Console.WriteLine("Seed skipped: tasks already exist.");
                    return;
                }
            }

              var tasks = new List<Task>
        {
            new Task { id = 1, description = "Learn C#", status = StatusEnum.Todo, createdAt = DateTime.Now, updatedAt = DateTime.Now },
            new Task { id = 2, description = "Build a task manager", status = StatusEnum.InProgress, createdAt = DateTime.Now, updatedAt = DateTime.Now },
            new Task { id = 3, description = "Test the application", status = StatusEnum.Done, createdAt = DateTime.Now, updatedAt = DateTime.Now }
        };

            string json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine("Seed completed.");
        }

   
   }
}
