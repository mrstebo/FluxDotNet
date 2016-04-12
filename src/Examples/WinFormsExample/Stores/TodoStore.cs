using System;
using System.Collections.Generic;
using System.Linq;
using FluxDotNet;
using WinFormsExample.Actions;
using WinFormsExample.Enums;
using WinFormsExample.Models;

namespace WinFormsExample.Stores
{
    public class TodoStore : Store
    {
        private readonly IList<Todo> _todos = new List<Todo>();
        private long _nextId = 1;

        public IEnumerable<Todo> Todos { get; private set; }
        public TodoFilters ActiveFilter { get; private set; }

        public TodoStore()
        {
            Dispatcher.Register<GetAllTodosAction>(OnGetAllTodos);
            Dispatcher.Register<GetActiveTodosAction>(OnGetActiveTodos);
            Dispatcher.Register<GetCompletedTodosAction>(OnGetCompletedTodos);
            Dispatcher.Register<CreateTodoAction>(OnCreateTodo);
            Dispatcher.Register<UpdateTodoAction>(OnUpdateTodo);

            Todos = new Todo[] {};
        }

        private void OnGetAllTodos(GetAllTodosAction action)
        {
            Todos = _todos;
            ActiveFilter = TodoFilters.All;

            EmitChange();
        }

        private void OnGetActiveTodos(GetActiveTodosAction action)
        {
            Todos = _todos.Where(x => !x.IsComplete);
            ActiveFilter = TodoFilters.Active;

            EmitChange();
        }

        private void OnGetCompletedTodos(GetCompletedTodosAction action)
        {
            Todos = _todos.Where(x => x.IsComplete);
            ActiveFilter = TodoFilters.Complete;

            EmitChange();
        }

        private void OnCreateTodo(CreateTodoAction action)
        {
            _todos.Add(new Todo
            {
                Id = _nextId++,
                Description = action.Description,
                IsComplete = false,
                CreatedAt = DateTime.UtcNow
            });

            EmitChange();
        }

        private void OnUpdateTodo(UpdateTodoAction action)
        {
            var todo = _todos.FirstOrDefault(x => x.Id == action.TodoId);

            if (todo != null)
            {
                todo.IsComplete = action.Completed;
            }

            EmitChange();
        }
    }
}
