using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Done.Data
{
    internal static class ApiSettings
    {
        internal static JsonSerializerOptions SerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        internal static Uri GetTodosURL => new Uri("https://jsonplaceholder.typicode.com/todos");
    }
}
