# 📘 Project Documentation: ITeGAMAX 4.0 Platform

## 🔍 Overview

This platform is composed of three distinct ASP.NET Core applications:
- **admin** – A back-office administration panel used for internal management.
- **site** – The public-facing site is designed for end-users.
- **CDN.ITEGAMAX.4.0** – Media content is served via CDN for optimal load time.

All applications are built with ASP.NET Core Razor Pages and share a common design philosophy and data access strategy using Entity Framework Core and MySQL.

---

## 🏗️ Architecture

The ITeGAMAX 4.0 platform is composed of three independent ASP.NET Core projects, each following the Model-View-Controller (MVC) architectural pattern:

**Admin** – A back-office application for managing content, settings, and users.
**Site** – The public-facing application that delivers dynamic, localized content and handles user sessions.
**CDN.ITEGAMAX.4.0** – A dedicated service for handling media uploads and serving static content via a globally distributed Content Delivery Network (CDN) to enhance performance and scalability.
Each project is self-contained and initializes its own middleware, services, and Razor Pages independently through its respective Program.cs file. This modular design enforces a clear separation of concerns and allows each application to evolve independently while sharing a consistent development approach.

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

All projects load structured configuration sections via the `builder.Configuration.GetSection(...).Bind(...)` pattern. These include:
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
   dotnet run --project CDN.ITEGAMAX.4.0
   dotnet run --project admin
   dotnet run --project site


---

## 📝 Notes from LIA with Itegamax

During my LIA (Lärande i Arbete) period at **Itegamax**, I worked on this project using a personalized connection string. The company granted access based on my IP address, which allowed me to work both from the office and remotely.

The code in this submission reflects what I developed and tested during that time. However, it's important to highlight the following:

* 🔒 **Access Limitation**: Since my internship has ended, the original connection string no longer works. This means the project cannot currently connect to the live database environment used during development.
* ⚠️ **Potential Runtime Issues**: You may encounter errors when trying to run the application locally, especially if the database connection is not reconfigured. These issues are related to deployment and configuration challenges that occurred during my time at the company.

💡 Tip: Update the connection string in appsettings.json with your own local or test database to run the project successfully.
🔒 Note: The original MariaDB instance used during development was hosted by Itegamax AB and required IP whitelisting for access. Since this access is no longer available, you will need to set up your own local or cloud-based database environment to run the application.

