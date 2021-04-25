# Code.Kata

This angular project consists of 2 pages.  One for uploading a file and adding records to a database, and another for displaying database contents into a table.

## Description

The code will process an input file.
Each line in the input file will start with a command. There are two possible commands.
The first command is Driver, which will register a new Driver in the app. Example: Driver
Dan The second command is Trip, which will record a trip attributed to a driver. The line
will be space delimited with the following fields: the command (Trip), driver name, start
time, stop time, miles driven. Times will be given in the format of hours:minutes. We'll
use a 24-hour clock and will assume that drivers never drive past midnight (the start
time will always be before the end time). Example: Trip Dan 07:15 07:45 17.3 Discard any
trips that average a speed of less than 5 mph or greater than 100 mph. Generate a
report containing each driver with total miles driven and average speed. Sort the output
by most miles driven to least. Round miles and miles per hour to the nearest integer.

Example Input:
* Driver Dan
* Driver Alex
* Driver Bob
* Trip Dan 07:15 07:45 17.3
* Trip Dan 06:12 06:32 21.8
* Trip Alex 12:01 13:16 42.0

Expected Output:
* Alex 42 miles @ 34mph
* Dan 39 miles @ 47mph
* Bob 0 miles

## About The Project

### Solution Structure
* Solution is organized into 4 seperate projects
  * Code.Kata.DataAccess - Entity Framework and Data Access Layer
  * Code.Kata.Repositories - Accesses database through DataAccess project.  These two projects could have been combined.
  * Code.Kata.Services - Web Services and business logic layer.  Business Logic Layer could have been put into it's own project seperate of services.
  * Code.Kata.WebApp - Consists of Angular web application user interface.

### Built With

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [Angular](https://angular.io)
* [Bootstrap](https://getbootstrap.com)


## Getting Started

### Dependencies

* node.js

### Installing

* build from visual studio
* use included test.txt file for file upload

### Executing program

* Click 'Update Driver Data' from navigation menu
* Click purple attachment icon
* Choose provided test.txt file from file dialog
* Application will process file
* Application will list successful and unsuccessful database updates
* Now click on 'Driver Reports' from navigation menu

## Authors

Contributors names and contact info

Daniel Wardlow

## Version History

* 0.1
    * Initial Release
