/*
	Get the Company Name, Order Date, and each order detail’s 
	Product name for USA customers only.
*/

USE Northwind;
GO

SELECT CompanyName, Orders.OrderDate, Products.ProductName
	FROM Customers
		INNER JOIN Orders
			ON Customers.CustomerID = Orders.CustomerID
		INNER JOIN [Order Details] ON
			[Order Details].OrderID = Orders.OrderID
		Inner JOin Products ON
			Products.ProductID = [Order Details].ProductID
		Where Customers.Country = 'USA';