/*
	Find the gross total (sum of quantity * unit price) for 
	all orders placed by B's Beverages and Chop-suey Chinese.
*/

USE Northwind;
GO

SELECT SUM(Quantity * UnitPrice) AS GrossTotal, c.CompanyName
FROM [Order Details] od
	INNER JOIN Orders o ON
		od.OrderID = o.OrderID
	INNER JOIN Customers c ON
		o.CustomerID = c.CustomerID
WHERE c.CustomerID = 'BSBEV' OR c.CompanyName = 'Chop-suey Chinese'
GROUP BY CompanyName