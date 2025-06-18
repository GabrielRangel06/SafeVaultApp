# SafeVaultSecureApp

A secure ASP.NET Core Web API project that demonstrates:

- ✅ Input validation and sanitization
- ✅ SQL injection and XSS prevention
- ✅ Authentication and Authorization with Role-Based Access Control (RBAC)
- ✅ Unit testing with xUnit
- ✅ Middleware implementation for input sanitization

---

## 📁 Project Structure

```
SafeVaultProject/
├── SafeVaultSecureApp/            # Main API project
│   ├── Controllers/
│   ├── Middleware/
│   ├── Services/
│   ├── Program.cs
│   ├── Startup.cs
│   └── SafeVaultSecureApp.csproj
│
├── SafeVaultSecureApp.Tests/      # Unit tests with xUnit
│   ├── AuthTests.cs
│   └── SafeVaultSecureApp.Tests.csproj
│
└── SafeVaultSecureApp.sln         # Solution file
```

---

## 🚀 How to Run the Project Locally

### 1. Restore dependencies

```bash
dotnet restore
```

### 2. Build the project

```bash
dotnet build
```

### 3. Run the API

```bash
dotnet run --project SafeVaultSecureApp
```

### 4. Access a test endpoint

```http
GET http://localhost:5000/api/users/admin
```

If the endpoint is protected, get a token:

```bash
curl -X POST "http://localhost:5000/api/users/login?username=admin&role=Admin"
```

Use the token in headers:

```bash
curl -H "Authorization: Bearer <YOUR_TOKEN>" http://localhost:5000/api/users/admin
```

---

## 🧪 Run Unit Tests

```bash
dotnet test
```

This runs the xUnit tests under `SafeVaultSecureApp.Tests`.

---

## 🔐 Security Features Implemented

- **Input Sanitization:** Middleware to encode query parameters and prevent script injection.
- **Authentication & Authorization:** Simple JWT-based system with roles (Admin, User).
- **XSS Protection:** Sanitizing inputs via `System.Web.HttpUtility.HtmlEncode()`.
- **Separation of concerns:** Logic handled via custom `AuthService`.

---



## 📄 License

This project is for educational and demonstration purposes only.