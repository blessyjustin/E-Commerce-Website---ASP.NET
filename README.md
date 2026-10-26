🛍️ E-Commerce Website – ASP.NET | C#

📌 Project Overview

This project demonstrates the development of an e-commerce website with user authentication, product categorization, product browsing, and administrative operations. It was developed as part of my practical learning in ASP.NET web application development.

✨ Features

👤 User Module

- User registration and login
- Browse product categories and subcategories
- View available products
- Access customer-facing pages

🔐 Admin Module

- Administrator registration and login
- Manage product categories and subcategories
- Add and manage products
- Access administrative pages

💳 Payment Service

- Separate WCF service project
- Service configuration using ".svc" and "Web.config"
- Payment-related service integration, depending on the implemented operations

🛠️ Technologies Used

Technology
C# - Server-side programming
ASP.NET Web Forms - Web application development
HTML, CSS, JavaScript, Bootstrap- User interface
SQL Server - Database management
ADO.NET - Database connectivity and operations
WCF - Service communication
Visual Studio - Development environment

🏗️ Architecture

The main web application follows a two-layer architecture:

1. Presentation Layer: ASP.NET Web Forms pages and their code-behind files handle the user interface and application interactions.
2. Data Access Layer: C# data-access code communicates with SQL Server using ADO.NET.

The WCF payment service is maintained as a separate service component.

⚙️ How to Run the Project

1. Clone or download this repository.
2. Open the solution file in Visual Studio.
3. Configure SQL Server and create or restore the required database.
4. Update the database connection string in the appropriate configuration file.
5. Build the solution and resolve any missing dependencies.
6. Configure the main web application and WCF service as required.
7. Run the application using IIS Express or IIS.

Prerequisites

- Visual Studio 2019
- Microsoft SQL Server
- IIS Express or IIS

🎓 Learning Outcomes

- Developing ASP.NET Web Forms applications using C#
- Implementing user authentication and administrative workflows
- Connecting web applications to SQL Server using ADO.NET
- Organizing applications using a two-layer architecture
- Understanding WCF service structure and integration

👩‍💻 Author - Blessy Justin
