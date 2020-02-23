using Done.Data.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Done.Data.Repositories
{
    public static class TodoRepository
    {
        public static List<Todo> GetTodos(int userId)
        {
            using HttpClient client = new HttpClient();
            client.BaseAddress = ApiSettings.GetTodosURL;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync($"?userId={userId}").Result;
            if (!response.IsSuccessStatusCode)
            {
                return FailGracefully(userId);
            }
            else
            {
                string msgContent = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<List<Todo>>(msgContent, ApiSettings.SerializerOptions);
            }
        }

        private static List<Todo> FailGracefully(int userId)
        {
            return new List<Todo>()
                {
                    new Todo
                    {
                        Title = "Controleren wat hier misgaat.",
                        Completed = false,
                        Id = -1,
                        UserId = userId
                    }
                };
        }
    }
}
