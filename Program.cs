
public enum TaskStatus
{
    New,
    InProgress,
    Done
}



class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();
    class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
    }
    class TaskManager 
    {
        public void AddTask()
        {
            
        }
        public void DeleteTask()
        {

        }
        public void getAllTasks()
        {

        }
        public void getIdTask()
        {

        }
        public void ChangeStatus()
        {

        }
    }

    static void Main()
    {

    }
}