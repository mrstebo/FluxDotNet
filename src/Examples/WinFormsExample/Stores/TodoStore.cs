using System.Collections.Generic;
using FluxDotNet;
using WinFormsExample.Actions;
using WinFormsExample.Models;

namespace WinFormsExample.Stores
{
    public class TodoStore : Store
    {
        private readonly IList<Todo> _todos = new List<Todo>();
        private long _nextId = 1;

        public IEnumerable<Todo> Todos
        {
            get { return _todos; }
        } 

        public TodoStore()
        {
            Dispatcher.Register<CreateTodoAction>(OnCreateTodo);
        }

        private void OnCreateTodo(CreateTodoAction action)
        {
            _todos.Add(new Todo
            {
                Id = _nextId++,
                Description = action.Description
            });

            EmitChange();
        }
    }
}
