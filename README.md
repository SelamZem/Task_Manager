### Task Manager
# Description
Task Manager is a command-line application built in C# that helps you manage your tasks. You can add, update, delete, and list tasks, as well as change their status to "To Do", "In Progress", or "Done". The tasks are saved to a JSON file for persistence, allowing you to keep track of your progress even after closing the application.

# Features
Add a new task: Adds a new task with a description and status.

Update a task: Allows you to change the description of an existing task.

Delete a task: Removes a task from the list.


Mark task status: Set the task's status to "In Progress", "Done", or "To Do".

List tasks: View all tasks or filter them by status (To Do, In Progress, Done).

# Installation
Clone the repository or download the project files to your local machine.
git clone [ https://github.com/SelamZem/TaskManage].git


# CLI Commands:

# To add a task:
task-cli add "Buy groceries"
# update a task:
task-cli update 1 "Buy groceries and cook dinner"
# To delete a task:
task-cli delete 1
# To mark a task as in progress:
task-cli mark-in-progress 1
# To mark a task as done:
task-cli mark-done 1
# To list all tasks:
task-cli list
# To list tasks by status (e.g., "Done", "ToDo", "In Progress"):
task-cli list done
task-cli list todo
task-cli list in-progress

<img width="950" alt="Task_Manager" src="https://github.com/user-attachments/assets/b15d97a7-cfc5-4300-964a-89f8f07cbb61" />
