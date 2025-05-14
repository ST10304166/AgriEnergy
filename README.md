AgriEnergy Platform
A digital ecosystem connecting farmers with green energy solutions for sustainable agriculture.

1.Project Overview
AgriEnergy is a web platform that bridges farmers and green energy providers, enabling:
•	Farmers to manage products and explore sustainable practices.
•	Agricultural employees to coordinate farm data and filter products by type/date.
•	Collaboration for eco-friendly farming solutions.
GitHub Repository: https://github.com/ST10304166/AgriEnergy.git

2.Setup Instructions
Prerequisites:
•	Visual Studio 2022
•	.NET 8 SDK
•	SQL Server (LocalDB or full instance)
•	Git (optional)
Installation:
•	Clone the repository: git clone https://github.com/ST10304166/AgriEnergy.git
•	Open the solution in Visual Studio 2022 (AgriEnergy.sln).

•	Restore NuGet packages: Right-click the solution → Restore NuGet Packages.

Database Setup:
Update the connection string in appsettings.json:
Eg. "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=AgriEnergy;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Run migrations to create and seed the database:
•	Open Package Manager Console (Tools → NuGet Package Manager).
Execute:
•	Add-Migration InitialCreate
•	Update-Database
This populates the database with sample farmers, employees, and products.

3.Running the Application
•	Set AgriEnergy.https as the startup project.
•	Press F5 or click Start Debugging.
•	Access the app at: https://localhost:7161.

4.User Roles & Features
Farmer
Add products with details:
•	Name (e.g., "Maize")
•	Category (e.g., "Grains")
•	Production date
•	View their product listings.
Employee
•	Add new farmer profiles (name, email, address, phone).

View and filter products by:
•	Date range
•	Product type
•	Access all farmer data.

5.Default Test Accounts
Use these credentials to log in:

Role		Email				Password
Farmer: 	farmer1@example.com	password123
Employee: 	admin@example.com		admin123
(Passwords are hashed.)

6. Troubleshooting
Issue					Solution
Database connection failed		Verify SQL Server is running. Check appsettings.json.
Migrations not applying		Run Update-Database in Package Manager Console.
Login issues				Use the exact test credentials above.

7.Additional information:
Employee can be created in the homepage and used to login as employee and access Employee capabilities
Role based login, 
Employee can also create farmer which can the be used to login to the farmer dashboard to access farmer capabilities
Creating Employee:
