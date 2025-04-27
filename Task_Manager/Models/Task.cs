using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager.Models
{

    public enum StatusEnum
    {
        Todo,
        InProgress,
        Done
    }
    internal class Task
    {
        public int id { get; set; }
        public string description { get; set; }
        public StatusEnum status { get; set; } = StatusEnum.Todo;
        public DateTime createdAt { get; set; }= DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}
