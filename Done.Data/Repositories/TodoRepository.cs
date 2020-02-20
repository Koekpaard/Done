using Done.Data.Models;
using System.Collections.Generic;

namespace Done.Data.Repositories
{
    public class TodoRepository
    {
        public List<Todo> GetTodos(int userId)
        {
            return new List<Todo>()
            {
                new Todo
                {
                    Id = 1,
                    UserId = 2,
                    Title = "Dummy",
                    Completed = false
                }
            };
        }
    }
}
