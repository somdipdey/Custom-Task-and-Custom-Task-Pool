# Custom-Task-Custom-Task-Pool
A C# program to run several tasks sequentially (but parallel to the main thread) and executed in the order that they were added to the class


# This C# program tries to solve the following challenge:

Write a C# class to execute a number of pieces of work (actions) in the background (i.e. without blocking the program’s execution).
•	The actions must be executed sequentially – one at a time
•	The actions must be executed in the order that they were added to the class
•	The actions are not necessarily added all at the same time
•	The actions are not necessarily all executed on the same thread

After completion, please let us know whether this was something you already knew how to do, or if you had to research it.  There isn’t a correct answer to this, but if you did research it, tell us how did you went about finding the information you needed.

# Solution:
In this implementation two new custom classes were created: GenericTaskList and Task.
The GenericTaskList manages all the custom tasks added to it. And all the custom tasks has some custom prperties such as Id, Messages and ThreadId on which the method of that task is running.

The method Add() in GenericTaskList adds new custom task to it.
The method CompleteTask() in the GenericTaskList completes/finishes the methods of the task sequentially and in the order the tasks were added to the list.
The method DisposeTasks() in GenericTaskList disposes of the objects of each task on the list.

On the main thread (main program) a GenericTaskList is initiated and then each custom task is added to that list. Each task runs parallel (in background) to the main thread, whereas the main thread does some other computation as well. After the main thread's work computation is done, the custom tasks are disposed.

# Console Output Screenshots

#### Custom Tasks running sequentially and in order on different threads:
![Alt text](https://user-images.githubusercontent.com/8515608/31317915-588af37a-ac41-11e7-89be-af4727b0e24e.PNG "Custom Tasks running sequentially and in order on different threads")

#### Main thread Id is different from the custom tasks' thread Id:

![Alt text](https://user-images.githubusercontent.com/8515608/31317917-61e8afd4-ac41-11e7-9ee4-15349ac1ea14.PNG "Main thread Id is different from the custom tasks' thread Id")

#### After all the custom tasks are completed, only mother (main) thread is running:
![Alt text](https://user-images.githubusercontent.com/8515608/31317919-679f23a4-ac41-11e7-8e2a-3095da415bad.PNG "After all the custom tasks are completed, only mother (main) thread is running")

#### After custom Dispose() is invoked, all the objects of custom tasks are disposed eventually:
![Alt text](https://user-images.githubusercontent.com/8515608/31317922-6a98a0b2-ac41-11e7-9e98-7b789b0e5619.PNG "After custom Dispose() is invoked, all the objects of custom tasks are disposed eventually")
