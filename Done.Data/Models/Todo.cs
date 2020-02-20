namespace Done.Data.Models
{
    // The structure of this class is meant reflect the examples in https://jsonplaceholder.typicode.com/todos
    public class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
