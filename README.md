# Inventory Management System ProjectAPP

## Table of Contents
- Project Overview
- Features
- Technologies Used
- Installation Instructions
- Usage
- API Endpoints
- Contributing
- Contact

## Project Overview
ProjectAPP is an inventory management system designed to efficiently manage items, categories, and suppliers. The application provides full CRUD (Create, Read, Update, Delete) functionalities for items and allows users to keep track of inventory details seamlessly. This project aims to enhance inventory tracking and management through a user-friendly API built with ASP.NET Core and Entity Framework.

## Features
- Manage items with details such as name, quantity, category, and supplier.
- Create, read, update, and delete operations for items.
- Categorize items into different categories for better organization.
- Link items to specific suppliers for improved tracking.
- API endpoints for seamless integration with front-end applications.

## Technologies Used
- **Backend**: ASP.NET Core
- **Database**: Entity Framework Core with SQL Server
- **Architecture**: MVC (Model-View-Controller) pattern
- **API**: RESTful API design
- **DTOs**: Data Transfer Objects for data management and manipulation
- **Dependency Injection**: For managing service instances
- **Asynchronous Programming**: Using async/await for non-blocking operations

## Installation Instructions
1. Clone the repository:

     ```bash
     git clone https://github.com/Idowu-Adeniyi/ProjectAPP.git
     cd ProjectAPP
  Or copy the URL: https://github.com/Idowu-Adeniyi/ProjectAPP
  Open your Visual Studio and click on clone repository, then paste the URL in the required field, select the path, and click on clone.

2. Open the project in your preferred IDE (e.g., Visual Studio, Visual Studio Code).
3. Restore the NuGet packages if you don’t have it installed on your computer:
     ```bash
     dotnet restore
4. Update the database connection string in the appsettings.json file:

            "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}

**Note:** Make sure you don’t have any other existing database on your computer to avoid collusion.

**Example for ProjectAPP connection string:** <br>
   {<br>
    "ConnectionStrings": {<br>
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=aspnet-ProjectAPP-308d3a41-07f4-4b02-884e-20d9a8d6bb69;Trusted_Connection=True;MultipleActiveResultSets=true"<br>
    },<br>
    "Logging": {<br>
      "LogLevel": {<br>
        "Default": "Information",<br>
        "Microsoft.AspNetCore": "Warning"<br>
      }<br>
    },<br>
    "AllowedHosts": "*"<br>
  }<br>

5. Run the migrations to set up the database:<br>
   NuGet Package Manager Console: update-database<br>

6. Refresh database from the SQL Server Object Explorer to apply changes: <br>
      Click the refresh button on the top left corner of the SQL Server Object Explorer<br>

   **Usage** <br>
    Once the application is set, you can access the API endpoints using tools like Swagger. The base URL for the API is:<br>
    URL: https://localhost:7158/Swagger/index.html<br>

   **API Endpoints** <br>
  |**Method**|**Endpoint**|**Description**           |<br>
  |GET       |  /ItemAPI    |Get a list of all items   |<br>
  |GET       |  /ItemAPI{id}    |Get a specific item by ID   |<br>
  |POST      |  /ItemAPI    |Create a new item   |<br>
  |PUT       |  /ItemAPI{id}   |Update an existing item   |<br>
  |DELETE    |  /ItemAPI{id}    |Delete an item by ID   |<br>

  **Request and Response Examples** <br>
  
-   Create a new item <br>
              Request:  { <br>
                  "itemName": "Nike",<br>
                  "quantity": 10,<br>
                  "categoryId": 1,<br>
                  "supplierId": 1<br>
              }<br>


              Response:  {<br>
                  "itemId": 1,<br>
                  "itemName": "Nike",<br>
                  "quantity": 10,<br>
                  "categoryId": 1,<br>
                  "supplierId": 1<br>
              }<br>

-     Update an item <br>
              Request: {<br>
                  "itemId": 1,<br>
                  "itemName": "Adidas",<br>
                  "quantity": 15,<br>
                  "categoryId": 2,<br>
                  "supplierId": 1<br>
              }<br>
              
              Response: (No Content)<br>
  
  **Contributing** <br>
  Contributions are welcome! If you'd like to contribute to this project, please follow these steps: <br>

  Fork the repository.<br>
  Create a new branch (git checkout -b feature-branch).<br>
  Make your changes.<br>
  Commit your changes (git commit -m 'Add some feature').<br>
  Push to the branch (git push origin feature-branch).<br>
  Create a pull request.<br>

  **Contact** <br>
  For questions or inquiries, please reach out to: <br>

  Name: Idowu Adeniyi<br>
  Email: adeniyi.idowu50@gmail.com<br>
  GitHub Profile: Idowu-Adeniyi<br>


 
    
 
  
 








