using System.Collections;
using System.Collections.Generic;
using Assignment1_DNP1.Models;

namespace Assignment1_DNP1.Data
{
    public interface ITodoData
    {
        IList<Todo> GetTodos();
        void AddTodo(Todo todo);
        void RemoveTodo(int todoId);
        void Update(Todo todo);
        Todo Get(int id);
    }
}