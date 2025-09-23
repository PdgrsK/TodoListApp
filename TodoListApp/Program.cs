using System;
using TodoListApp.Models;
using TodoListApp.Managers;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your Personal To-Do Manager");

            // Создаем экземпляр менеджера списка дел
            var todoManager = new TodoListManager();

            // Теперь вызываем методы через экземпляр менеджера
            todoManager.DisplayTodoList();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}


