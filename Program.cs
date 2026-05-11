using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

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
           
        }

        static void AddTask()
        {
            
        }

        static void ChangeStatus()
        {
           
        }

        static void DeleteTask()
        {
            
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
