using System;
using TodoListApp.Models;
using TodoListApp.Managers;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your Ultimate To-Do List!");

            var todoManager = new TodoListManager();

            RunInteractive(todoManager); // Запускаем основной интерактивный режим

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Метод, отвечающий за основной интерактивный цикл приложения
        static void RunInteractive(TodoListManager manager)
        {
            while (true)
            {
                manager.DisplayTodoList(); // Показываем текущий список дел
                Console.WriteLine("\nAvailable commands: add, toggle, exit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.Trim().ToLower(); // Используем ?. для null-conditional, если Console.ReadLine() вернет null

                bool operationSuccessful = false; // Флаг для индикации успеха операции

                switch (command)
                {
                    case "add":
                        Console.Write("Enter the description for the new task: ");
                        string description = Console.ReadLine();
                        operationSuccessful = manager.AddTask(description);
                        break;

                    case "toggle":
                        Console.Write("Enter the ID of the task to toggle completion: ");
                        string taskIdInput = Console.ReadLine();
                        if (int.TryParse(taskIdInput, out int taskId))
                        {
                            operationSuccessful = manager.ToggleTaskCompletion(taskId);
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid ID format. Please enter a number.");
                            operationSuccessful = false; // Считаем операцию неуспешной
                        }
                        break;

                    case "exit":
                        return; // Выход из цикла RunInteractive, а затем и из программы

                    default:
                        Console.WriteLine("Error: Unknown command. Please try again.");
                        operationSuccessful = false; // Неизвестная команда - неуспех
                        break;
                }

                // Небольшая пауза, чтобы пользователь увидел сообщение об успехе/ошибке
                if (operationSuccessful || command == "add" || command == "toggle" || command == "exit" || command == null) // Если команда была valid, и мы не выходим
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    // Если была ошибка, но не exit, тоже можно дать паузу
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}
