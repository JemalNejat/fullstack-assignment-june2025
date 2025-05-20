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
## 🌐 CDN Integration
To enhance performance and reduce load times, the project utilizes a Content Delivery Network (CDN) for serving static assets such as:

CSS frameworks (e.g., Bootstrap)
JavaScript libraries (e.g., jQuery, Popper.js)
Fonts and icons (e.g., Google Fonts, Font Awesome)
These resources are referenced via CDN links in the layout files of both the Admin and Site applications.

## 🚀 How It Works
Instead of sending images, files, and other static content directly from the main server every time someone visits the site, Azure CDN stores copies of these files on many servers located around the world.

When a user accesses the website, the CDN delivers these files from the server closest to them geographically, which significantly improves loading speed because the data travels a shorter distance.

**This approach offers several benefits**:

⚡ **Faster Load Times**: Users receive content more quickly, improving the overall experience.
📉 **Reduced Server Load**: The main server handles fewer requests for static content, allowing it to focus on dynamic processing.
🌍 **Global Reach**: Users from different regions experience consistent performance.
🔁 **Improved Caching**: Frequently used libraries are often already cached in users’ browsers from other sites.
This setup aligns with modern web development best practices and contributes to a smoother, more responsive experience for users worldwide.

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


3. Update `appsettings.json` with your local database credentials.
4. Run each project individually using:

   ```bash
   dotnet run --project ADMIN.ITEGAMAX.4.0
   dotnet run --project SITE.ITEGAMAX.4.0.2


---

## 📝 Notes from LIA with Itegamax

During my LIA (Lärande i Arbete) period at **Itegamax**, I worked on this project using a personalized connection string. The company granted access based on my IP address, which allowed me to work both from the office and remotely.

The code in this submission reflects what I developed and tested during that time. However, it's important to highlight the following:

* 🔒 **Access Limitation**: Since my internship has ended, the original connection string no longer works. This means the project cannot currently connect to the live database environment used during development.
* ⚠️ **Potential Runtime Issues**: You may encounter errors when trying to run the application locally, especially if the database connection is not reconfigured. These issues are related to deployment and configuration challenges that occurred during my time at the company.

I recommend updating the connection string in `appsettings.json` with your own local or test database if you wish to run the project.

