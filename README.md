# ✅ TaskFlow

**Project Type:** ASP.NET Core Web API  
**.NET Version:** .NET 8  
**C# Version:** 12.0  

---

## 🎯 Purpose  
TaskFlow is a backend API for managing tasks. It provides endpoints for creating, reading, updating, and deleting.  
The architecture follows best practices for maintainability and scalability.  

---

## 🚀 Main Features  
- **Authentication & Authorization:** Secure login/register with JWT, role-based access (Admin/User).
- **CRUD Operations:** Endpoints for creating, retrieving, updating, and deleting tasks, categories, and comments.
- **User Management:** Register, login, and seed admin user.
- **DTOs:** Clean API contracts using Data Transfer Objects.
- **Repository Pattern:** Abstracted data access via interfaces and infrastructure layer.
- **AutoMapper:** Mapping between domain models and DTOs.
- **EF Core Migrations:** Code-first database management and seeding.
- **Swagger/OpenAPI:** Interactive API documentation.
- **Role-Based Access:** Restrict endpoints to specific roles.
  
---

## 📂 Project Structure  
- **TaskFlow.WebAPI:** Controllers, authentication, and startup configuration.
- **TaskFlow.Application:** DTOs, repository interfaces, and AutoMapper profiles.
- **TaskFlow.Domain:** Domain models (User, TaskItem, Category, Comment).
- **TaskFlow.Infra:** Repository implementations, migrations, and DbContext.
---

## 🛠️ Technologies Used  
- ASP.NET Core (.NET 8)
- C# 12
- Entity Framework Core (Code First)
- SQL Server
- AutoMapper
- JWT Authentication
- Swagger/OpenAPI

---

## ⚙️ Setup Instructions  
1. Clone the repository:  
   ```bash
   git clone https://github.com/Bardia2005Kh/TaskFlow
   cd TaskFlow
   ```
2. Update the connection string in **appsettings.json** to point to your SQL Server.  
3. Run database migrations:  
   ```bash
   dotnet ef database update
   ```
4. Build and run the solution:  
   ```bash
   dotnet run
   ```
5. Open Swagger UI in your browser:  
   👉 https://localhost:****/swagger  

---

## 📌 Extensibility  
- 🔐 Role-based Authentication & Authorization (JWT)
- 📊 Logging & Monitoring (planned)
- ✅ Input Validation
- 📖 API Documentation with Swagger/OpenAPI
- ⚡ Pagination & Filtering for tasks (planned)
- 🧪 Unit & Integration Tests (planned)  

---

## 🤝 Contribution & License  
- Contributions are welcome!  
- Licensed under the **MIT License**.  

---

👨‍💻 Built with ❤️ using **ASP.NET Core 8 & C# 12**  
