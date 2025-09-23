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
        private int _nextId = 1;

        // Конструктор: инициализация тестовыми данными
        public TodoListManager()
        {
            // Тестовые данные для демонстрации
            _todoList.Add(new TodoItem(_nextId++, "Buy groceries"));
            _todoList.Add(new TodoItem(_nextId++, "Read a book"));
            _todoList.Add(new TodoItem(_nextId++, "Go for a walk"));
        }

        // Метод для получения списка задач (можно использовать для внешних операций)
        public List<TodoItem> GetTodoList()
        {
            return _todoList;
        }

        // Метод для добавления новой задачи
        // Возвращает true при успехе, false при неудаче
        public bool AddTask(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Error: Task description cannot be empty.");
                return false;
            }
            _todoList.Add(new TodoItem(_nextId++, description));
            Console.WriteLine($"Success: Task '{description}' added.");
            return true;
        }

        // Метод для переключения статуса выполнения задачи
        // Возвращает true при успехе, false при неудаче (неверный ID)
        public bool ToggleTaskCompletion(int taskId)
        {
            var taskToToggle = _todoList.FirstOrDefault(t => t.Id == taskId);
            if (taskToToggle == null)
            {
                Console.WriteLine($"Error: Task with ID {taskId} not found.");
                return false;
            }

            taskToToggle.IsCompleted = !taskToToggle.IsCompleted;
            Console.WriteLine($"Success: Task {taskId} status updated to {taskToToggle.GetStatusDisplay()}.");
            return true;
        }

        // Метод для отображения списка дел в консоли
        public void DisplayTodoList()
        {
            Console.Clear(); // Очищаем консоль для лучшей читаемости
            Console.WriteLine("--- Your To-Do List ---");
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



    }
}

