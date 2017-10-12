/*
	Find the total sales by supplier 
	ordered from most to least.
*/

USE Northwind;
GO
SELECT SUM(od.Quantity * od.UnitPrice) AS TotalSales, s.CompanyName
FROM Suppliers s
	INNER JOIN Products p ON
		s.SupplierID = p.SupplierID
	INNER JOIN [Order Details] od ON
		p.ProductID = od.ProductID
GROUP BY s.CompanyName
ORDER BY TotalSales DESC