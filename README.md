## 📚 Code and Documentation Submission – June 2025

**Author:** Nejat Jemal
**School:** Chas Academy
**Repository:** [fullstack-assignment-june2025](https://github.com/chas-academy/fullstack-assignment-june2025)
**Live URL:** *([itehamax](https://itegamax.se/))*

---

### 🚀 Project Overview

This project converts a static website into a dynamic, database-driven application using **ASP.NET Core MVC**, **Entity Framework Core**, and **MySQL**. It was built during an internship at **Itegamax AB** to address real business needs for content flexibility and maintainability.

The system includes a user-friendly Admin Panel for managing services, articles, and projects. The site is fully responsive and optimized for performance.

---

### 🧩 Tech Stack

| Layer     | Technology                       |
| --------- | -------------------------------- |
| Backend   | ASP.NET Core MVC (C#)            |
| ORM       | Entity Framework Core            |
| Database  | MySQL                            |
| Frontend  | Razor Pages, Bootstrap 5, CSS    |
| Dev Tools | Visual Studio, Git, Azure DevOps |
| Hosting   | Azure / Loopia                   |

---

### 🏗️ Architecture

* **MVC Pattern** for clear separation of concerns
* **Admin Panel** for content management
* **EF Core Migrations** with a code-first approach
* **CDN** for media delivery
* **Docker-ready** for container deployment

---

### ⚙️ Setup Instructions

#### 🔧 Requirements

* Visual Studio 2022
* .NET 6 SDK
* MySQL 8+
* Git

#### 🛠 Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/chas-academy/fullstack-assignment-june2025.git
   cd fullstack-assignment-june2025
   ```

2. **Configure the Database Connection**

   Edit `appsettings.json` with your connection details:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "server=localhost;port=3306;database=your_db;user=root;password=your_password;"
   }
   ```

3. **Apply Migrations**

   In the Package Manager Console:

   ```powershell
   Update-Database
   ```

4. **Run the Application**

   Press `F5` in Visual Studio or use:

   ```bash
   dotnet run
   ```

---

## 🔐 Database Access Requirements

This project connects to a **private MySQL server** hosted by **Itegamax AB**.

* The server is **not publicly accessible**.
* To connect, your **IPv4 address must be manually whitelisted by a server admin**.
* This setup is restricted to **Itegamax employees and approved LIA (internship) students only**.
* Even if you provide your IPv4 address, access **will not be granted** unless you're part of the company or officially enrolled in their LIA program.

If your IP is not whitelisted, you’ll see the error:

```
Host 'your-ip' is not allowed to connect to this MySQL server
```

> Only internal admins at Itegamax can approve access. This restriction is in place for security and compliance reasons.

---

### 👤 User Roles

| Role    | Capabilities                    |
| ------- | ------------------------------- |
| Admin   | Full CRUD access to all modules |
| Visitor | View public-facing pages        |

---

### 🧪 Features Implemented

* Admin dashboard for managing articles, services, and projects
* Fully responsive frontend (Bootstrap 5)
* CDN for fast image loading
* EF Core integration with MySQL
* Component-based Razor structure
* Basic role-based content visibility

---

### 📊 Performance Highlights

| Metric              | Old Static Site | New Dynamic Site | Improvement      |
| ------------------- | --------------- | ---------------- | ---------------- |
| Page Load Time      | \~3.5s          | \~1.2s           | \~65% faster     |
| Content Update Time | 1–2 days        | \~15 mins        | >90% faster      |
| Mobile Support      | Limited         | Fully responsive | Greatly improved |

---

### 📁 Folder Structure

```
├── Controllers/        # MVC Controllers
├── Models/             # Entity Models
├── Views/              # Razor Views
├── Data/               # DbContext and Migrations
├── wwwroot/            # Static Assets (CSS/JS)
├── Program.cs          # App Startup
├── appsettings.json    # Configuration
```

---

### ✅ Status

✔️ MVP Complete
✔️ Tested by internal team
🚧 Future features like chatbot and RBAC in development

