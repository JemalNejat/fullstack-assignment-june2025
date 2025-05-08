# 📘 Project Documentation: ITeGAMAX 4.0 Platform

## 🔍 Overview

This platform is composed of two distinct ASP.NET Core applications:
- **ADMIN.ITEGAMAX.4.0** – A back-office administration panel used for internal management.
- **SITE.ITEGAMAX.4.0.2** – The public-facing site is designed for end-users.

Both applications are built with ASP.NET Core Razor Pages and share a common design philosophy and data access strategy using Entity Framework Core and MySQL.

---

## 🏗️ Architecture

The system is divided into two separate applications to enforce the separation of concerns:
- The **Admin** application focuses on content, settings, and user management.
- The **Site** application delivers dynamic content, localized views, and user session handling.

Each project initializes its own middleware, services, and Razor Pages independently via the `Program.cs` file.

---

## 🧰 Technologies Used

- ⚙️ **ASP.NET Core Razor Pages**
- 🛢️ **Entity Framework Core (MySQL)**
- 📦 **Custom Configuration Binding**
- 🌍 **Localization (CultureInfo)**
- 🗂️ **Session Management**
- 🔁 **Dependency Injection**
- 🧱 **Modular Architecture using Areas and Services**

---

## ⚙️ Configuration and Dependency Injection

Both projects load structured configuration sections via the `builder.Configuration.GetSection(...).Bind(...)` pattern. These include:
- `CUSTAPPSETTINGS` for custom app configurations.
- `COMPANYSETTINGS` for business-specific preferences.
- `ConnectionStrings` for database access.

Services are registered using `builder.Services`, including:
- 📝 Razor Pages
- 🛢️ Database context: `ITeGAMAX4Context`
- 🗂️ Session services (in `SITE`)
- 🌍 Localization options

---

## 🗄️ Database Integration

Entity Framework Core is used for ORM, connected to a MariaDB instance via a `MariaDbConnectionString`.

The `ADMIN` project includes a scaffolded database context (`Scaffold-DB.txt`) indicating model-first or reverse-engineering of the database.

---

## 🌐 Middleware and Localization

In `SITE.ITEGAMAX.4.0.2`, custom middleware is used to enhance request processing. This includes:
- 🌍 **Localization Middleware**: Supporting multiple cultures using `RequestLocalizationOptions`.
- 🗂️ **Session Middleware**: Enables stateful user interactions across requests.

---

## ⚠️ Challenges Encountered

- 🌍 **Multi-language Support**: Implementing culture-aware responses and ensuring translations are applied correctly.
- 🔄 **Cross-project Configuration**: Managing shared settings while maintaining separation between admin and site modules.
- 🧩 **Database Context Consistency**: Ensuring model synchronization during scaffold/regeneration steps.

---

## 🚀 How to Run

### 📋 Prerequisites
- [.NET SDK 7.0 or higher](https://dotnet.microsoft.com/)
- [MySQL or MariaDB server](https://mariadb.org/)

### 🛠️ Steps
1. Clone the repository and extract both projects.
2. Restore dependencies:
   ```bash
   dotnet restore
````

3. Update `appsettings.json` with your local database credentials.
4. Run each project individually using:

   ```bash
   dotnet run --project ADMIN.ITEGAMAX.4.0
   dotnet run --project SITE.ITEGAMAX.4.0.2
   ```

---

## 📝 Notes from LIA with Itegamax

During our LIA (Lärande i Arbete) period at **Itegamax**, we accessed and worked on the project using personalized connection strings. The company granted access based on each student's IP address, allowing us to work both from the office and remotely.

The code in this submission represents what was actively developed and tested during that time. However, it's important to note the following:

* 🔒 **Access Limitation**: Since our internship has ended, the original connection strings no longer work. This means the project cannot currently connect to the live database setup we used during development.
* ⚠️ **Potential Runtime Issues**: You may encounter errors when trying to run the application locally, especially if the database connection is not reconfigured. These issues stem from deployment and configuration challenges that occurred during our time at the company and may still persist in the current version.

We recommend updating the connection string in `appsettings.json` with your own local or test database if you wish to run the project.



