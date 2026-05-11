using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManagerConsole
{
    public enum TaskStatus
    {
        New,
        InProgress,
        Done
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }



    class Program
    {

        static List<TaskItem> tasks = new List<TaskItem>();
        static string FileName = "tasks.json";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(" МЕНЕДЖЕР ЗАДАЧ ");
                Console.WriteLine("1. Переглянути список задач");
                Console.WriteLine("2. Додати нову задачу");
                Console.WriteLine("3. Змінити статус задачі");
                Console.WriteLine("4. Видалити задачу");
                Console.WriteLine("5. Зберегти та вийти");
                Console.Write("\nВиберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": ViewTasks(); break;
                    case "2": AddTask(); break;
                    case "3": ChangeStatus(); break;
                    case "4": DeleteTask(); break;
                    case "5": SaveData(); exit = true; break;
                    default: Console.WriteLine("Невірний вибір..."); Console.ReadKey(); break;
                }
            }
        }

        static void ViewTasks()
        {
            
            foreach (TaskItem item in tasks)
            {
                Console.WriteLine(item.Id + ". " + item.Title
                    + "\nDescription: " + item.Description
                    + "\nStatus: " + item.Status
                    + "\n");
            }
            Console.ReadLine();
        }

        static void AddTask()
        {
            TaskItem task = new TaskItem();
            if (tasks.Count > 0)
            {
                task.Id = tasks.Max(t => t.Id) + 1;
            }
            else
            {
                task.Id = 0;
            }
            Console.WriteLine("Title: ");
            task.Title = Console.ReadLine();
            Console.WriteLine("Description: ");
            task.Description = Console.ReadLine();
            Console.WriteLine("Status: ");
            TaskStatus status;
            if (Enum.TryParse(Console.ReadLine(), out status))
            {
                task.Status = status;
            }
            tasks.Add(task);

        }

        static void ChangeStatus()
        {
            Console.WriteLine("Write Status's id: ");
            int id = int.Parse(Console.ReadLine());
            TaskStatus status;
            Console.WriteLine("Wtite new status: ");
            Enum.TryParse(Console.ReadLine(), out status);

            foreach (TaskItem item in tasks)
            {
                if(item.Id == id)
                {
                    item.Status = status;
                }
                break;
            }
        }

        static void DeleteTask()
        {
            Console.WriteLine("Write id: ");
            int id = int.Parse(Console.ReadLine());
            foreach (TaskItem item in tasks)
            {
                if (item.Id == id)
                {
                    tasks.Remove(item);
                    break;
                }
            }
        }

        static void SaveData()
        {
            try
            {
                string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FileName, json);
                Console.WriteLine("Дані збережено у файл tasks.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні");
            }
        }

        static void LoadData()
        {
            if (File.Exists(FileName))
            {
                try
                {
                    string json = File.ReadAllText(FileName);
                    tasks = JsonSerializer.Deserialize<List<TaskItem>>(json);
                }
                catch
                {
                    tasks = new List<TaskItem>();
                }
            }
        }
    }
}