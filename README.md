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
- **CRUD Operations:** Endpoints for creating, retrieving (single and all), updating, and deleting.  
- **DTOs:** Uses Data Transfer Objects for input and output to keep API contracts clean.  
- **Repository Pattern:** Data access is abstracted via interfaces and implemented in a separate infrastructure layer.  
- **AutoMapper:** Used for mapping between domain models and DTOs.
  
---

## 📂 Project Structure  
- **TaskFlow.WebAPI:** Contains controllers and startup configuration.  
- **TaskFlow.Application:** Contains DTOs, repository interfaces, and AutoMapper profiles.  
- **TaskFlow.Domain:** Contains domain models.  
- **TaskFlow.Infra:** Contains repository implementations, Migrations and DbContext.  

---

## 🛠️ Technologies Used  
- **ASP.NET Core (.NET 8)**  
- **C# 12**  
- **Entity Framework Core (Code First)**  
- **SQL Server**  
- **AutoMapper**  
- **DTOs for clean API contracts**  

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
- 🔐 Authentication & Authorization (JWT)  
- 📊 Logging & Monitoring  
- ✅ Input Validation  
- 📖 API Documentation with Swagger/OpenAPI  
- ⚡ Pagination & Filtering for tasks 
- 🧪 Unit & Integration Tests  

---

## 🤝 Contribution & License  
- Contributions are welcome!  
- Licensed under the **MIT License**.  

---

👨‍💻 Built with ❤️ using **ASP.NET Core 8 & C# 12**  
