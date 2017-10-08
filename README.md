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