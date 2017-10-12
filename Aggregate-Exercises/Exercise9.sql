/*
	Challenge: 
	Show the total amount of orders by
	year and country.  Data should be ordered 
	by year ascending and total descending.
	
	TotalSales    Year     Country
	41907.80      1996     USA
	37804.60      1996     Germany
	etc...
	
	Hint: Research the DatePart() function
*/

USE Northwind;
GO

SELECT SUM(od.UnitPrice * od.Quantity) as TotalSales, c.Country, 
	DATEPART(yyyy, o.OrderDate) as [Year]
FROM Orders o
	INNER JOIN [Order Details] od ON o.OrderID = od.OrderID
	INNER JOIN Customers c ON o.CustomerID = c.CustomerID
GROUP BY c.Country, DATEPART(yyyy, o.OrderDate)
ORDER BY [Year], TotalSales DESC
 