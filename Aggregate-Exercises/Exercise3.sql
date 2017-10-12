/*
	Find the gross total of all orders (sum of quantity * unit price) 
	for each customer, order it in descending order by the total.
*/

USE Northwind;
GO

SELECT SUM(Quantity * UnitPrice) AS GrossTotal, c.CompanyName
FROM Customers c
	INNER JOIN Orders o ON
		c.CustomerID = o.CustomerID
	INNER JOIN [Order Details] od ON
		o.OrderID = od.OrderID
GROUP BY CompanyName
ORDER BY GrossTotal DESC
