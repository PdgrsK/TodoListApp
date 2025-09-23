using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Managers
{
    internal class TodoListManager
    {
        private List<TodoItem> _todoList = new List<TodoItem>();
        private int _nextId;

        // Конструктор менеджера
        public TodoListManager()
        {
            // Инициализируем тестовыми данными при создании менеджера
            _todoList.Add(new TodoItem(1, "Buy groceries"));
            _todoList.Add(new TodoItem(2, "Read a book"));
            _todoList.Add(new TodoItem(3, "Go for a walk"));
        }

        // Метод для отображения списка дел в консоли
        public void DisplayTodoList()
        {
            Console.WriteLine("\n--- Your To-Do List ---");
            if (_todoList.Count == 0)
            {
                Console.WriteLine("Your list is empty!");
            }
            else
            {
                foreach (var item in _todoList)
                {
                    Console.WriteLine($"{item.Id}. {item.GetStatusDisplay()} {item.Description}");
                }
            }
            Console.WriteLine("-----------------------");

        }

        // Метод для добавления новой задачи
        public void AddTask(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                _todoList.Add(new TodoItem(_nextId++, description));
                Console.WriteLine("Task added successfully!");
            }
            else
            {
                Console.WriteLine("Task description cannot be empty.");
            }
        }

        // Метод для переключения статуса выполнения задачи
        public bool ToggleTaskCompletion(int taskId)
        {
            var taskToToggle = _todoList.FirstOrDefault(t => t.Id == taskId);
            if (taskToToggle != null)
            {
                taskToToggle.IsCompleted = !taskToToggle.IsCompleted;
                Console.WriteLine($"Task {taskId} completion status updated.");
                return true;
            }
            else
            {
                Console.WriteLine($"Task with ID {taskId} not found.");
                return false;
            }
        }


    }
}

