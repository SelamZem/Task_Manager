using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Task_Manager.Models;

namespace Task_Manager.TaskManager
{
    internal class Manager
    {
        private List<Task> _tasks;
        private readonly string filePath;

        public Manager(string _filepath)
        {
            this.filePath = _filepath;
            _tasks = LoadTasks();
        }

        //load the tasks
        public List<Task> LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<Task> tasks = JsonConvert.DeserializeObject<List<Task>>(json);

                return tasks;
            }
            Console.WriteLine("The file doesnt Exist!");
            return new List<Task>();
        }
        // track changes while Saving(SaveChanges)
        public bool SaveTask()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_tasks, Formatting.Indented);
                File.WriteAllText(filePath, json);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong...");
                return false;
            }
        }


        //Managing functions which the User interact with
        public bool AddTask(string description)
        {
           
            int newId = _tasks.Count > 0 ? _tasks.Max(t => t.id) + 1 : 1;

        
            Task newTask = new Task
            {
                id = newId,
                description = description
            };

         
            _tasks.Add(newTask);
            return SaveTask();
        }

        public bool UpdateTask(int id, string description)
        {
            Task taskToUpdate = _tasks.FirstOrDefault(t => t.id == id);

            
            if (taskToUpdate == null)
            {
                Console.WriteLine($"Task with Id {id} not found.");
           
            }

            taskToUpdate.description = description;
            taskToUpdate.updatedAt = DateTime.Now; 

            return SaveTask();
        }

        public bool DeleteTask(int id) 
        {
            Task taskToDelete = _tasks.FirstOrDefault(t => t.id == id);
            if(taskToDelete == null) {
                Console.WriteLine($"Task with Id {id} not found.");
                
            }
            _tasks.Remove(taskToDelete);
            return SaveTask();
        }

        public bool MarkInProgress(int id)
        {
            Task taskMarkInProgress = _tasks.FirstOrDefault(t => t.id == id);
            if (taskMarkInProgress == null)
            {
                Console.WriteLine($"Task with Id {id} not found.");
                
            }
            taskMarkInProgress.status = StatusEnum.InProgress;
            taskMarkInProgress.updatedAt = DateTime.Now;
            return SaveTask();
        }
        public bool MarkCompleted(int id) 
        { 
            Task taskMarkCompleted = _tasks.FirstOrDefault(t => t.id==id);
            if (taskMarkCompleted == null) 
            {
                Console.WriteLine($"Task with Id {id} not found.");
            }
            taskMarkCompleted.status = StatusEnum.Done;
            taskMarkCompleted.updatedAt = DateTime.Now;
            return SaveTask();
        }
        public void ListAllTasks()
        {
            if (_tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

       
            foreach (var task in _tasks)
            {
                Console.WriteLine($"ID: {task.id}, Description: {task.description}, Status: {task.status}, CreatedAt: {task.createdAt}, UpdatedAt: {task.updatedAt}");
            }
        }
        public void ListDone()
        {
           
            var doneTasks = _tasks.Where(t => t.status == StatusEnum.Done).ToList();

            if (doneTasks.Count == 0)
            {
                Console.WriteLine("No tasks marked as Done.");
                return;
            }
            foreach (var task in doneTasks)
            {
                Console.WriteLine($"ID: {task.id}, Description: {task.description}, Status: {task.status}, CreatedAt: {task.createdAt}, UpdatedAt: {task.updatedAt}");
            }
        }
        public void ListInProgress()
        {

            var doneTasks = _tasks.Where(t => t.status == StatusEnum.InProgress).ToList();

            if (doneTasks.Count == 0)
            {
                Console.WriteLine("No tasks marked as In Progress.");
                return;
            }
            foreach (var task in doneTasks)
            {
                Console.WriteLine($"ID: {task.id}, Description: {task.description}, Status: {task.status}, CreatedAt: {task.createdAt}, UpdatedAt: {task.updatedAt}");
            }
        }
        public void ListToDo()
        {

            var doneTasks = _tasks.Where(t => t.status == StatusEnum.Todo).ToList();

            if (doneTasks.Count == 0)
            {
                Console.WriteLine("No tasks marked as To Do.");
                return;
            }
            foreach (var task in doneTasks)
            {
                Console.WriteLine($"ID: {task.id}, Description: {task.description}, Status: {task.status}, CreatedAt: {task.createdAt}, UpdatedAt: {task.updatedAt}");
            }
        }

    }
}
