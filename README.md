
# 📦 HappyInventoryAPP - Inventory CRUD System (Blazor WASM)

A simple, lightweight inventory management CRUD application built with **Blazor WebAssembly**, using a clean architecture with three distinct layers: **Client**, **Server**, and **Shared**. The app features **FluentValidation** for robust form validation and **SQLite** for local database storage.

---

## 🧱 Project Structure



## 🚀 Features

✅ Full CRUD operations for:
- 🏷️ Items  
- 🏢 Warehouses  
- 👤 Users  

✅ SQLite-based lightweight local storage  
✅ Clean separation of concerns using **Blazor WASM architecture**  
✅ Integrated validation using **FluentValidation**  
✅ Responsive and modular codebase

---

## 🔧 Technologies Used

| Tech Stack         | Description                        |
|--------------------|------------------------------------|
| Blazor WebAssembly | SPA frontend (Client project)      |
| ASP.NET Core       | Web API backend (Server project)   |
| SQLite             | Local embedded DB (using `sqlite-net-pcl`) |
| FluentValidation   | Elegant and fluent validation logic |
| C# & .NET 6        | Base language and framework        |

---

## 📁 Shared Models

Defined under `Shared/Models/`, and used by both server and client:

- **Item.cs**: Represents a stock item with pricing, quantity, and warehouse reference.
- **User.cs**: Represents a system user with basic authentication info.
- **Warehouse.cs**: Represents a physical location for item storage.

Each model includes a corresponding **Validator class** (e.g., `ItemValidator.cs`) for validation rules using FluentValidation.

---

## ✅ Validation Logic (FluentValidation)

- **ItemValidator**:
  - `ItemName`, `SKUCode`: required, 3–50 characters
  - `Qty`, `CostPrice`, `MSRPPrice`: required, quantity ≥ 1

- **UserValidator**:
  - `FirstName`, `LastName`, `Username`: required, 3–50 characters
  - `Password`: required, 6–50 characters

- **WarehouseValidator**:
  - `WarehouseName`, `Address`, `City`, `Country`: required, 3–50 characters

---

## 📦 NuGet Packages

All installed in the `.csproj` file:

```xml
<PackageReference Include="FluentValidation" Version="11.2.2" />
<PackageReference Include="sqlite-net-pcl" Version="1.8.116" />
<PackageReference Include="System.Linq.Dynamic.Core" Version="1.3.0" />
