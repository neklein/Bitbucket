/*
	Show the number of orders placed by customers 
	from fewest to most provided the customer has 
	a minimum of 4 orders.
*/

USE Northwind;
GO

SELECT COUNT(o.OrderID) as NumOrders, c.CompanyName
FROM Customers c
	INNER JOIN Orders o ON
		c.CustomerID = o.CustomerID
GROUP BY c.CompanyName
HAVING COUNT(o.OrderID) >= 4
ORDER BY NumOrders

