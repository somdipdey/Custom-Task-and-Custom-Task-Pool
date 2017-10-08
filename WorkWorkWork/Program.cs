using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
//This project uses an additional dependecy named SystemPerformance developed by Somdip Dey
//SystemPerformance Nuget Package: https://www.nuget.org/packages/SystemPerformance/
using SystemPerformance;

/*
 * This program is written by Somdip Dey, Copyright @ 2017
 * 
 * Goal of this program:
 * 
 * Write a C# class to execute a number of pieces of work (actions) in the background (i.e. without blocking the program’s execution).
    •	The actions must be executed sequentially – one at a time
    •	The actions must be executed in the order that they were added to the class
    •	The actions are not necessarily added all at the same time
    •	The actions are not necessarily all executed on the same thread

    After completion, please let us know whether this was something you already knew how to do, or if you had to research it.  There isn’t a correct answer to this, but if you did research it, tell us how did you went about finding the information you needed.
 *
 */

namespace WorkWorkWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add new custom tasks to custom task pool
            //This [Add method] can be invoked at any point of the program
            var taskList = new GenericTaskList<Task>();
            for (int i = 1; i <= 6; i++)
            {
                taskList.Add(new Task(i));
            }

            // Initialise System Performance (A Nuget package developed by Somdip Dey) before spawning each task on a new thread
            PerformanceTracker sysTracker = new PerformanceTracker();

            //Run each custom task on different threads
            foreach (Task thisTask in taskList.list)
            {
                // If the CPU of the system is not performing critically (is too busy)
                // then spawn each thread with above normal priority
                // Or else spawn each thread with normal priority
                if (!sysTracker.CPU_Performing_Critical)
                {
                    Thread thisThread = new Thread(thisTask.Start);
                    thisThread.IsBackground = true;
                    thisThread.Priority = ThreadPriority.AboveNormal;
                    thisThread.Start();
                }
                else
                {
                    Thread thisThread = new Thread(thisTask.Start);
                    thisThread.IsBackground = true;
                    thisThread.Priority = ThreadPriority.Normal;
                    thisThread.Start();
                }
            }

            //A loop to make the main thread do some work parallel to the other child threads
            for (int work = 1; work < 10; work++ )
            {
                //do some work on the main thread
                var calculatePower = Math.Pow(2, work % 10);
                Console.WriteLine(">>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>");
                Console.WriteLine("Loop work No.: " + work);
                
                //check what each task is doing-->
                foreach(Task thistask in taskList.list)
                {
                    Console.WriteLine("----");
                    Console.WriteLine("TaskId: " + thistask.Id);
                    Console.WriteLine("Message: " + thistask.Message);
                    Console.WriteLine("Running on Thread Id: " + thistask.MotherThreadId);
                }
                Console.WriteLine(">>>>>>>>>>>>>>");
                Console.WriteLine(">>>>>>>>>>>>>>");
                Console.WriteLine("MAIN THREAD of ID: " + System.Threading.Thread.CurrentThread.ManagedThreadId + " is still running!");
            }

            Console.WriteLine(">>>>>>>>>>>>>>");
            Console.WriteLine(">>>>>>>>>>>>>>");
            Console.WriteLine(System.Environment.NewLine); Console.WriteLine(System.Environment.NewLine);
            Console.WriteLine("Invoking action to complete all tasks in the pool -->");

            //call this method to complete all the custom tasks
            taskList.CompleteTask();

            //check what each task is up to after the completion-->
            foreach (Task thistask in taskList.list)
            {
                Console.WriteLine("----");
                Console.WriteLine("TaskId: " + thistask.Id);
                Console.WriteLine("Message: " + thistask.Message);
                Console.WriteLine("Running on Thread Id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            }

            Console.WriteLine("MAIN THREAD of ID: " + System.Threading.Thread.CurrentThread.ManagedThreadId + " is still running!");
            Console.WriteLine("MAIN THREAD's work complete! Please press ENTER to exit.");
            Console.WriteLine(System.Environment.NewLine);

            //Dispose method to dispose of all objects of custom tasks
            taskList.DisposeTasks();

            //check what each task is up to after the dispose operation-->
            Console.WriteLine("After invoking Dispose() method -->");
            foreach (Task thistask in taskList.list)
            {
                Console.WriteLine("----");
                Console.WriteLine("TaskId: " + thistask.Id);
                Console.WriteLine("Message: " + thistask.Message);
                Console.WriteLine("Running on Thread Id: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            }

            //This is to keep the console visible to the user
            Console.ReadLine();
        }
    }
}
