using System;
using System.Collections.Generic;

namespace TodoList
{
    internal class TodoList
    {
        private int currentId = 1;

        private List<TodoTask> Tasks = new List<TodoTask>();

        public void AddTask(TodoTask task)
        {
            task.Id = currentId;
            Tasks.Add(task);
            currentId++;
        }

        public void DisplayAllTasks()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("Задач пока нет");
                return;
            }
            foreach (TodoTask task in Tasks)
            {
                Console.WriteLine("Id: " + task.Id);
                Console.WriteLine("Title: " + task.Title);
            }
        }

        public void RemoveTask(int removeId)
        {
            var taskToRemove = Tasks.Find(t => t.Id == removeId);
            if (taskToRemove != null && Tasks.Remove(taskToRemove))
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    Tasks[i].Id = i + 1;
                }
                currentId = Tasks.Count + 1;
            }
            else
            {
                Console.WriteLine("Удаление не удалось. Задача не найдена");
            }
        }
    }
}

