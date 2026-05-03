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
```

---

## 🛠️ Setup & Tools

Use **Command Line** or **Developer PowerShell** to set up the environment.

### 1. Install Dependencies
Run the following commands to ensure all necessary Entity Framework Core and Swagger packages are installed at version 9.0.0:
```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
dotnet add package Swashbuckle.AspNetCore --version 7.2.0
```

### 2. Maintenance & Cleanup
If you need to reset the tools or resolve version conflicts:
```bash
dotnet remove package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
dotnet clean
dotnet restore
```

### 3. Database Initialization
Generate the SQLite database schema using Entity Framework Migrations:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 🚀 How To Test

After running `dotnet run`, your command prompt should indicate the active listening ports:

> `info: Microsoft.Hosting.Lifetime[14] --> Now listening on: https://localhost:7016`  
> `info: Microsoft.Hosting.Lifetime[14] --> Now listening on: http://localhost:5197`

*Note: Replace `5197` or `7016` in the commands below with your actual local port numbers.*

### 1. Verify API & Swagger
Check if the Swagger JSON metadata is being generated correctly:
```bash
curl -k -I https://localhost:7016/swagger/v1/swagger.json
```

**Visualize the API:** Open your browser and navigate to:  
[https://localhost:7016/swagger](https://localhost:7016/swagger)

---

### 2. Create New Products
Add data to the SQLite database using POST requests.

**Add Apple:**
```bash
curl -k -X POST https://localhost:7016/api/products -H "Content-Type: application/json" -d "{\"name\": \"Apple\", \"price\": 10}"
```

**Add Mango:**
```bash
curl -k -X POST https://localhost:7016/api/products -H "Content-Type: application/json" -d "{\"name\": \"Mango\", \"price\": 15}"
```

---

### 3. Retrieve Product Data
Fetch the list of all products currently stored in the database:
```bash
curl -k https://localhost:7016/api/products
```

---

### 4. Delete Product Data
Remove a specific product by its unique ID (e.g., ID: 1):
```bash
curl -k -X DELETE https://localhost:7016/api/products/1
```

---

### 5. Final Verification
Retrieve the data again to confirm the deletion:
```bash
curl -k https://localhost:7016/api/products
```

<br><br>


# Now Let's Play with the Customer Table

Testing the CRUD functionality for the Customer endpoints using the active ports (`7016` for HTTPS).

### 1. Add Customer Data
Populate the SQLite database with initial customer records:
```bash
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Budi\", \"City\": \"Jakarta\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Yuni\", \"City\": \"Bekasi\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Andi\", \"City\": \"Depok\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Budi2\", \"City\": \"Jakarta\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Budi3\", \"City\": \"Jakarta\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Budi4\", \"City\": \"Jakarta\"}"
curl -k -X POST https://localhost:7016/api/customers -H "Content-Type: application/json" -d "{\"name\": \"Budi5\", \"City\": \"Jakarta\"}"
```

---

### 2. Retrieve Customer Data
Fetch all current records to verify IDs and details:
```bash
curl -k https://localhost:7016/api/customers
```

---

### 3. Delete Customer Data
Demonstrating deletion by ID, by Name, and by a combination of both:

**Delete by ID:**
```bash
curl -k -X DELETE https://localhost:7016/api/customers/1
```

**Delete by Name:**
```bash
curl -k -X DELETE https://localhost:7016/api/customers/by-name/Budi2
```

**Strict Delete (Match ID and Name):**
```bash
curl -k -X DELETE https://localhost:7016/api/customers/by-id-name/5/Budi3
curl -k -X DELETE https://localhost:7016/api/customers/by-id-name/6/Budi4
```

---

### 4. Update Customer Data
Demonstrating standard updates, renaming via Name, and strict multi-parameter updates:

**Update by ID (Standard):**
```bash
curl -k -X PUT https://localhost:7016/api/customers/7 -H "Content-Type: application/json" -d "{\"id\": 7, \"name\": \"Budi5.1\", \"city\": \"Jakarta\"}"
```

**Update by Name (Renaming):**
```bash
curl -k -X PUT https://localhost:7016/api/customers/by-name/Budi5.1 -H "Content-Type: application/json" -d "{\"id\": 7, \"name\": \"Budi5.1.2\", \"city\": \"Jakarta\"}"
```

**Strict Update (Match ID and Old Name):**
```bash
curl -k -X PUT https://localhost:7016/api/customers/by-id-name/7/Budi5.1.2 -H "Content-Type: application/json" -d "{\"id\": 7, \"name\": \"Budi5.1.2.3\", \"city\": \"Jakarta\"}"
```

**Strict Update (City Change only):**
```bash
curl -k -X PUT https://localhost:7016/api/customers/by-id-name/7/Budi5.1.2.3 -H "Content-Type: application/json" -d "{ \"id\": 7, \"name\": \"Budi5.1.2.3\", \"city\": \"Jakarta Selatan\"}"
```

```