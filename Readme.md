# C# SQLite API CRUD 

This project is a lightweight, high-performance Web API built with .NET 9 and Entity Framework Core, using SQLite as the database engine[cite: 1]. It features full **Swagger (OpenAPI) integration** for interactive documentation and API testing[cite: 1].

## 📂 Folder Structure

```text
csharp-sqlite-api-crud
├── Controllers/
├── Entities/
├── Data/
├── Properties/
│   └── launchSettings.json
├── appsettings.Development.json
├── appsettings.json
├── csharp-sqlite-api-crud.csproj
├── csharp-sqlite-api-crud.csproj.user
├── csharp-sqlite-api-crud.http
├── csharp-sqlite-api-crud.sln
└── Program.cs
```[cite: 1]

---

## 🛠️ Setup & Tools

Use **Command Line** or **Developer PowerShell** to set up the environment.[cite: 1]

### 1. Install Dependencies
Run the following commands to ensure all necessary Entity Framework Core and Swagger packages are installed at version 9.0.0:[cite: 1]
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
dotnet add package Swashbuckle.AspNetCore --version 7.2.0
```[cite: 1]

### 2. Maintenance & Cleanup
If you need to reset the tools or resolve version conflicts:[cite: 1]
```bash
dotnet remove package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
dotnet clean
dotnet restore
```[cite: 1]

### 3. Database Initialization
Generate the SQLite database schema using Entity Framework Migrations:[cite: 1]
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```[cite: 1]

---

## 🚀 How To Test

After running `dotnet run`, your command prompt should indicate the active listening ports:[cite: 1]

> `info: Microsoft.Hosting.Lifetime[14] --> Now listening on: https://localhost:7016`  
> `info: Microsoft.Hosting.Lifetime[14] --> Now listening on: http://localhost:5197`[cite: 1]

*Note: Replace `5197` or `7016` in the commands below with your actual local port numbers.*[cite: 1]

### 1. Verify API & Swagger
Check if the Swagger JSON metadata is being generated correctly:[cite: 1]
```bash
curl -k -I https://localhost:7016/swagger/v1/swagger.json
```[cite: 1]

**Visualize the API:** Open your browser and navigate to:  
[https://localhost:7016/swagger](https://localhost:7016/swagger)[cite: 1]

---

### 2. Create New Products
Add data to the SQLite database using POST requests.[cite: 1]

**Add Apple:**
```bash
curl -k -X POST https://localhost:7016/api/products -H "Content-Type: application/json" -d "{\"name\": \"Apple\", \"price\": 10}"
```[cite: 1]

**Add Mango:**
```bash
curl -k -X POST https://localhost:7016/api/products -H "Content-Type: application/json" -d "{\"name\": \"Mango\", \"price\": 15}"
```[cite: 1]

---

### 3. Retrieve Product Data
Fetch the list of all products currently stored in the database:[cite: 1]
```bash
curl -k https://localhost:7016/api/products
```[cite: 1]

---

### 4. Delete Product Data
Remove a specific product by its unique ID (e.g., ID: 1):[cite: 1]
```bash
curl -k -X DELETE https://localhost:7016/api/products/1
```[cite: 1]

---

### 5. Final Verification
Retrieve the data again to confirm the deletion:[cite: 1]
```bash
curl -k https://localhost:7016/api/products
```[cite: 1]