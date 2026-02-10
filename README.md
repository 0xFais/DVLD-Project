# 🚗 DVLD Management System

**Driving & Vehicle License Department – Desktop Application**

## 📌 Project Overview

The **DVLD Management System** is a desktop-based application developed using **C# WinForms** and **.NET Framework 4.8**.
The project simulates the workflow of a **Driving & Vehicle License Department (DVLD)** and provides tools to manage people, users, drivers, license applications, tests, and driving licenses.

The system was built as a **real-world administrative application**, focusing on:

* Clean architecture
* Maintainability
* Realistic business logic
* Secure and efficient database access

This project is suitable for:

* Learning advanced WinForms development
* Practicing 3-Tier Architecture
* Graduation or portfolio projects

---

## 🧱 Architecture (3-Tier Architecture)

The application is built using a **3-Tier Architecture**, separating responsibilities into clear layers:

### 1️⃣ Presentation Layer (UI)

* Implemented using **Windows Forms (WinForms)**
* Contains all Forms and UserControls
* Responsible for:

  * Displaying data using DataGridViews
  * Handling user input
  * Applying filters and search options
  * Communicating with the Business Logic Layer

---

### 2️⃣ Business Logic Layer (BLL)

* Contains all business rules and validations
* Acts as an intermediary between UI and DAL
* Responsible for:

  * Validating data
  * Enforcing workflow rules
  * Preventing invalid operations

---

### 3️⃣ Data Access Layer (DAL)

* Built using **ADO.NET**
* Uses **raw SQL queries** (no stored procedures)
* Responsible for:

  * Executing SQL commands
  * Handling database connections
  * Returning results to the Business Layer

---

## 🛠️ Technologies Used

* **Language:** C#
* **Framework:** .NET Framework 4.8
* **UI:** WinForms
* **Database:** SQL Server
* **Data Access:** ADO.NET (Raw SQL)
* **Architecture:** 3-Tier Architecture
* **IDE:** Visual Studio 2019+

---

## 📂 Project Structure

```
DVLD_Project
│
├── PresentationLayer
│   ├── Forms
│   ├── UserControls
│   └── MainForm
│
├── BusinessLayer
│   ├── Entities
│   ├── Business Rules
│   └── Validation
│
├── DataAccessLayer
│   ├── Database Connection
│   ├── SQL Queries
│   └── ADO.NET Logic
│
├── App.config
├── Program.cs
└── DVLD.sln
```

---

## 🧩 System Features

### 👤 People Management

* Add, update, delete, and search people
* Store personal and identification information
* People represent the **base entity** of the system

---

### 👥 Users Management

* Convert an existing **Person** into a **System User**
* Every user must already exist as a person
* Manage user accounts (create, update, deactivate)

---

### 🚘 Drivers Management

* Convert people into drivers
* Maintain driver records
* Link drivers with issued licenses

---

### 📝 Driving License Applications

* Local Driving License Applications
* International Driving License Applications
* Track application details and status
* Handle application fees

---

### 🧪 Driving Tests Management

* Vision Test
* Written Test
* Practical Driving Test
* Schedule and record test results

---

### 🪪 License Management

* Issue new licenses
* Renew existing licenses
* Replace lost or damaged licenses
* Track expiration dates

---

### 🔎 DataGridView Filtering & Search

* **Every DataGridView in the system includes filtering**
* Filters are implemented using parameterized SQL `WHERE` clauses
* Searchable fields include:

  * IDs
  * Full Names
  * License Numbers
  * Application Status
* Improves usability and data accessibility

---

## 🗄️ Database Queries & Data Access Design

### 🔗 ADO.NET & Raw SQL Usage

* All database operations are written using **raw SQL queries**
* No stored procedures are used
* Queries are centralized inside the **Data Access Layer**

This approach:

* Keeps SQL logic transparent
* Makes debugging easier
* Allows full control over query behavior

---

### 🔐 SQL Injection Safety

✅ **The application is protected against SQL Injection**

* All queries use **parameterized SQL commands**
* User input is never concatenated into SQL strings
* Parameters are passed using `SqlParameter`

This ensures:

* Inputs are treated as data, not executable SQL
* Protection against malicious injection attempts
* Secure database operations

---

### 🧠 Query Complexity

The queries range from **simple to moderately complex**, reflecting real administrative systems.

#### Simple Queries

* Insert, update, delete records
* Retrieve lists for DataGridViews
* Basic search and filtering

#### Moderately Complex Queries

* Multiple table joins
* Conditional checks before insert/update
* Ensuring valid workflow transitions
* Preventing duplicate or inconsistent data

The design prioritizes:

* Readability
* Maintainability
* Realistic business logic

---

### ⚡ Performance Considerations

Performance best practices applied include:

* Selecting only required columns (avoiding `SELECT *`)
* Using indexed columns for filtering
* Opening database connections only when required
* Closing connections immediately after execution
* Reusing query logic where possible

---

### 🧪 Error Handling Strategy

* Try-Catch blocks implemented in DAL
* Controlled exception propagation
* Prevents application crashes
* Makes future logging integration easier

---

### 🧠 Data Integrity & Validation

Data integrity is enforced at multiple levels:

* **Business Layer:** Primary validation and rule enforcement
* **Database Layer:** Relationships, keys, and constraints

This ensures consistent and reliable data storage.

---

## ⚙️ How to Run the Project

1. Install **Visual Studio 2019 or later**
2. Ensure **.NET Framework 4.8** is installed
3. Install **Microsoft SQL Server**
4. Create the database and tables
5. Update the **Connection String** in `App.config`
6. Build and run the solution

---

## 🎯 Project Objectives

* Build a real-world WinForms system
* Apply 3-Tier Architecture properly
* Use ADO.NET securely and efficiently
* Practice structured and maintainable coding

---

## 📚 Learning Outcomes

* Strong understanding of WinForms
* Practical layered architecture experience
* Secure database access with ADO.NET
* Realistic business logic implementation
* Improved software design skills

---

## 🚀 Future Enhancements

* Add reporting (RDLC / Crystal Reports)
* Improve UI/UX
* Add logging and diagnostics
* Introduce role-based permissions
* Migrate to WPF or ASP.NET Core

---

## 🤝 Contribution

Contributions are welcome:

1. Fork the repository
2. Create a new branch
3. Commit your changes
4. Submit a Pull Request
