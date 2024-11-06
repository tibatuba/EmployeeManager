**Employee Database**


  An ASP.NET Core MVC web application for managing employees and departments.
  This app allows users to create, edit, view, and delete employee records,
  filter employees by department, and find employees based on criteria such
  as salary and joining date.

features:
  - "Employee Management: Add, view, edit, and delete employee records."
  - "Department Management: Add and view department records."
  - "Filtering Options:"
      - "Display employees with salaries above a specified amount."
      - "List employees who joined after a specific date."
      - "Show employees in a selected department."

requirements:
  - .NET 6.0 SDK
  - Visual Studio 2022
  - SQLite

setup_steps:
  - step 1: "Clone the repository"
    command: |
      git clone https://github.com/your-username/Final2_TibaAljaqobi.Operations.git
      cd Final2_TibaAljaqobi.Operations

  - step 2: "Configure the database connection"
    file: appsettings.json
    update: |
      "ConnectionStrings": {
          "SQLiteConn": "Data Source=./DataLayer/EmployeeDb.sqlite"
      }

  - step 3: "Apply migrations to set up the database"
    command: dotnet ef database update

  - step 4: "Run the application"
    command: dotnet run
    access_urls:
      - https://localhost:5001
      - http://localhost:5000

usage_instructions:
  - "Add Employee: Go to 'Add Employee' to add a new employee."
  - "Employee List by Department: Select a department from the dropdown to view employees in that department."
  - "Highly Paid Employees: Enter a minimum salary to filter employees by salary."
  - "New Employees: Enter a date to list employees who joined after that date."

project_structure:
  Controllers:
    - EmployeeController.cs
    - DepartmentController.cs
  Models:
    - Employee.cs
    - Department.cs
  Views:
    - Employee (folder for employee-related views)
    - Department (folder for department-related views)

contributing:
  Contributions are welcome! Feel free to open issues or submit pull requests with improvements or fixes.
