Dynamic Web Development at Itegamax – Thesis Project 2025
Introduction
This documentation provides a detailed explanation of the code structure, use of C#, MySQL database integration, connection string configuration, and how to run the project for the 'fullstack-assignment-june2025' GitHub project. The project includes an ASP.NET Core MVC admin panel and a frontend site using Razor Pages, Bootstrap, MySQL, and Entity Framework Core.
Project Overview
The project involves transforming a static corporate website into a dynamic, scalable, and maintainable web platform using ASP.NET Core MVC. The system includes a MySQL database, an admin panel for content management, and a responsive frontend built with Razor Pages and Bootstrap.
Code Structure
The repository is structured as follows:
/admin/         # Admin panel (ASP.NET Core MVC)
/site/          # Frontend site (Razor Pages, Bootstrap)
/documentation/ # Thesis and screenshots (optional)
README.md       # Project overview and setup instructions
Use of C#
C# is used extensively throughout the project for backend development. The ASP.NET Core MVC framework leverages C# for creating controllers, models, and services. Entity Framework Core, an Object-Relational Mapper (ORM), is used to interact with the MySQL database using C#.
MySQL Database Integration
The project uses MySQL as the database management system. Entity Framework Core is used for database operations, including migrations and CRUD operations. The database schema includes tables for articles, services, projects, and social media links.
Connection String Configuration
The connection string for the MySQL database is configured in the appsettings.json file. Due to security measures, the connection string is restricted by IP address and can only be used from specific locations (e.g., Itegamax office or home). Ensure that your IP address is whitelisted to access the database.
How to Run the Project
1. Clone the repository:
   git clone https://github.com/JemalNejat/fullstack-assignment-june2025.git
2. Open the solution in Visual Studio 2022.
3. Update the database connection string in appsettings.json.
4. Run EF Core migrations:
   dotnet ef database update
5. Run the application:
   dotnet run
Meeting Assignment Goals
This project demonstrates the ability to work as a Fullstack Web Developer by:
1. Developing a dynamic web application using ASP.NET Core MVC and Razor Pages.
2. Integrating a MySQL database with Entity Framework Core for data management.
3. Creating a responsive frontend using Bootstrap.
4. Implementing secure and efficient CRUD operations.
5. Configuring and managing connection strings with IP restrictions for security.
