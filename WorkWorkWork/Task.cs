using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWorkWork
{
    // Custom task which inherits IDisposable
    // to dispose of objects if and when required for better 
    // garbage collection. ALthough majority of objects and 
    // garbage collection is managed byC# itself, so there is
    // no need to use Dispose() explicitly. But sometimes if you are 
    // invoking methods to deal with external files or connections to databases 
    // then it is advisable to use IDisposable to manage and free resources effectively
    public class Task: IDisposable
    {
        public int Id { get; set; }
        public int MotherThreadId { get; set; }
        public string Message { get; set; }
        public bool running { get; set; }
        bool disposed = false;

        //Initialise each porperty of the custom task
        public Task(int ID)
        {
            Id = ID;
            Message = "This task with Id: " + Id + " is just initiated";
        }

        // This method runs a method/work on this custom task
        public void Start()
        {
            MotherThreadId = (int)System.Threading.Thread.CurrentThread.ManagedThreadId;
            running = true;

            while(running)
            {
                Message = "This task with Id: " + Id + " is currently running" ;
            }
            Message = "This task with Id: " + Id + " is completed";
        }

        // Public implementation of Dispose pattern callable by consumers
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here
                // For the moment the relevant fields such as ID, ThreadId, Message
                // are set to -1 or null where -1 Id translates to null as well
                Id = -1;
                MotherThreadId = -1;
                Message = null;
            }

            // Free any unmanaged objects here
            disposed = true;
        }
    }
}
