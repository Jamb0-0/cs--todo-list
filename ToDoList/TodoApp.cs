using System;

namespace TodoList
{

    internal class TodoApp
    {
        private TodoList _todoList = new();

        public TodoApp()
        {
            _todoList.LoadFromFile();
        }

        public void Run()
        {
            bool exit = true;
            while (exit)
            {
                ShowMenu();
                exit = HandleInput();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nЧто вы хотите сделать?");
            Console.WriteLine("1. Показать все задачи");
            Console.WriteLine("2. Добавить задачу");
            Console.WriteLine("3. Удалить задачу");
            Console.WriteLine("4. Выход");
        }

        private bool HandleInput()
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                switch (number)
                {
                    case 1:
                        _todoList.DisplayAllTasks();
                        break;

                    case 2:
                        Console.WriteLine("Введите название задачи:");
                        string title = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine("Название не может быть пустым");
                            return true;
                        }
                        else
                        {
                            TodoTask task = new TodoTask { Title = title };
                            _todoList.AddTask(task);
                            Console.WriteLine("Задача добавлена!\n");
                        }
                            break;

                    case 3:
                        Console.WriteLine("Введите номер задачи: ");
                        if (int.TryParse(Console.ReadLine(), out int idForRemove))
                        {
                            _todoList.RemoveTask(idForRemove);
                            Console.WriteLine("Задача удалена.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Выход из программы...");
                        _todoList.SaveToFile();
                        return false;
                    default:
                        Console.WriteLine("Неверный номер команды! Выберите 1-4");
                        break;
                }
                return true;
            }
            else
            {
                Console.WriteLine("Неверный номер команды! Выберите 1-4");
                return true;
            }
        }
    }
}