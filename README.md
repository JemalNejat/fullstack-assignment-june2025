
## 📚 Fullstack Assignment – June 2025  
Author: Nejat Jemal  
School: Chas Academy  
Repository: fullstack-assignment-june2025  
Live URL: ([itegamax](https://itegamax.se/))





## 🚀 Project Overview

This project transforms a previously static website into a fully dynamic, database-driven web application using ASP.NET Core MVC, Entity Framework Core, and MySQL. It was developed during an internship at Itegamax AB to meet real-world needs for scalable, flexible, and easily maintainable web platforms.

The system allows non-technical administrators to manage content such as services, articles, and projects through an intuitive Admin Panel. The site is fully responsive and optimized for performance and usability.

---

## 🧩 Tech Stack

| Layer     | Technology                   |
|-----------|------------------------------|
| Backend   | ASP.NET Core MVC (C#)         |
| ORM       | Entity Framework Core         |
| Database  | MySQL                        |
| Frontend  | Razor Pages, Bootstrap 5, CSS |
| Dev Tools | Visual Studio, Git, Azure DevOps |
| Hosting   | Azure / Loopia               |

---

## 🏗️ Architecture

- **MVC Pattern:** Clean separation between data, views, and logic.  
- **Admin Panel:** Dynamic management of articles, services, and projects.  
- **EF Core Migrations:** Code-first approach for syncing models with the database.  
- **CDN Integration:** Media content is served via CDN for optimal load time.  
- **Docker-ready:** Configured for containerized deployment environments.  

---

## ⚙️ Setup Instructions

### 🔧 Requirements
- Visual Studio 2022  
- .NET 6 SDK  
- MySQL 8+  
- Git  

### 🛠 Installation

1. Clone the repository

```bash
git clone https://github.com/chas-academy/fullstack-assignment-june2025.git
cd fullstack-assignment-june2025
````

2. Configure Database Connection
   Edit `appsettings.json` and update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;port=3306;database=your_db;user=root;password=your_password;"
}
```

3. Apply Migrations
   Run in the Package Manager Console:

```powershell
Update-Database
```

4. Run the application
   Press F5 in Visual Studio or run:

```bash
dotnet run
```

---

## 👤 User Roles

| Role    | Capabilities                    |
| ------- | ------------------------------- |
| Admin   | Full CRUD access to all modules |
| Visitor | View public-facing pages        |

---

## 🧪 Features Implemented

* Admin dashboard for article/service/project CRUD
* Responsive layout (Bootstrap 5)
* CDN for image loading
* EF Core with MySQL
* Modular Razor Components
* Role-based content visibility (basic setup)

---

## 📊 Performance Highlights

| Metric              | Old Static Site | New Dynamic Site | Improvement      |
| ------------------- | --------------- | ---------------- | ---------------- |
| Page Load Time      | \~3.5s          | \~1.2s           | \~65% faster     |
| Content Update Time | 1–2 days        | \~15 mins        | >90% faster      |
| Mobile Support      | Limited         | Full responsive  | Greatly improved |

---

## 📁 Folder Structure

```bash
├── Controllers/        # MVC Controllers
├── Models/             # Entity Models
├── Views/              # Razor Views
├── Data/               # DbContext and Migrations
├── wwwroot/            # Static Assets (CSS/JS)
├── Program.cs          # App Startup
├── appsettings.json    # Configuration
```

---

## ✅ Status

* ✔️ MVP Complete
* ✔️ Tested by internal team
* 🚧 Future features like chatbot and RBAC in pipeline

```




```
