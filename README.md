# Web Application Portfolio Project

This application was developed for Web Application module, as coursework portfolio project @ WIUT by student ID: 00016438

## Application Overview

This project implements a **Student Grade Tracker**, as determined by the calculation:

**00016438 modulo 20 = 18**

**Topic**: Student Grade Tracker

## Prerequisites

To run this application, please make sure that you have installed the following:

- **Backend Requirements**:
  - .NET 6.0 SDK or later
  - Entity Framework Core (v9.0.0)
  - EF Core Sql Server (v9.0.0)
  - EF Core Tools (v9.0.0)
  - AutoMapper (v13.0.1)

- **Frontend Requirements**:
  - Node.js (v18.19.1 or later)
  - Angular CLI

- **Database**
  - SQL Server Express (v2019 or later)
  - SQL Server Management Studio

## Installation and Setup

1. **Clone the Repository**:

   ```bash
   git clone https://github.com/wiut16438/WAD.GradeTracker.00016438.git
   cd WAD.GradeTracker.00016438
   ```

2. **Backend Setup**:
    - Open Visual Studio.
    - Go to **File > Open > Project/Solution**.
    - Navigate to the cloned repository folder and select the `.sln` file.
    - In **Solution Explorer**, right-click the solution name.
    - Select **Restore NuGet Packages**. This will download all necessary dependencies for the project.
  
  **In case required**:
    - Configure Connection Strings by opening the `appsettings.json`
    - Update the connection string with your database credentials
  
  **If the database is not set up**:
    - Open the **Package Manager Console** (`Tools > NuGet Package Manager > Package Manager Console`)
    - Select **WIUT.Server.00016438.DAL** as your default project
    - Run the following command to apply migrations:

    ```bash
    Update-Database
    ```

   If migrations need to be created, use:
   
     ```bash
     Add-Migration InitialMigration
     Update-Database
     ```

3. **Frontend Setup**:
   - Navigate to the frontend folder:
     ```bash
     cd frontend
     ```
   - Install dependencies:
     ```bash
     npm install
     ```
   - Start the Angular development server:
     ```bash
     ng serve
     ```

## Features

- **Backend**:
  - ASP.NET Core with Entity Framework.
  - CRUD functionality for managing student grades.
  - Fully documented with Swagger.

- **Frontend**:
  - Angular SPA.
  - Responsive design for improved user experience.
  - CRUD operations integrated with the backend API.


## Additional Info

- **Demo Video**: 
- **External Libraries Used**:
  - Entity Framework Core (v9.0.0)
  - EF Core Sql Server (v9.0.0)
  - EF Core Tools (v9.0.0)
  - AutoMapper (v13.0.1)
