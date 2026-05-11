
public enum TaskStatus
{
    New,
    InProgress,
    Done
}
class Program
{
    
    class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }


    }

    static void Main()
    {

    }
}