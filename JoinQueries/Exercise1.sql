/*
	Get a list of each employee first name and lastname
	and the territory names they are associated with
*/

USE Northwind;
GO

select FirstName, LastName, Territories.TerritoryDescription
From Employees
	Inner JOIN EmployeeTerritories 
		ON Employees.EmployeeID = EmployeeTerritories.EmployeeID
	Inner Join Territories
		on Territories.TerritoryID = EmployeeTerritories.TerritoryID

GO