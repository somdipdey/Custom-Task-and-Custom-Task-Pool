using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWorkWork
{
    // A custom generic list to hold all the tasks
    public class GenericTaskList<T> where T: Task
    {
        // List to hold the custom tasks
        public List<T> list = new List<T>();

        // Add each custom task to the list to create a task pool
        public void Add(T value)
        {
            list.Add(value);
            list = list.OrderBy(e => e.Id).ToList();
        }

        // To fetch this task list index
        public T this[int index]
        {
            get { throw new NotImplementedException();}
        }

        // Method to finish all running task in the task pool
        public void CompleteTask()
        {
            foreach(T value in list)
            {
                value.running = false;
            }
        }

        // Method to dispose all the objects of custom tasks properly
        public void DisposeTasks()
        {
            foreach (T value in list)
            {
                value.Dispose();
            }
        }
    }
}
