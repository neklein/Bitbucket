/*
	Find the average freight paid for orders 
	placed by companies in the USA
*/

USE Northwind;
GO

SELECT AVG(Freight) AS AvgFreight
FROM Orders o
	INNER JOIN Customers c ON
		o.CustomerID = c.CustomerID
	WHERE c.Country = 'USA'

	