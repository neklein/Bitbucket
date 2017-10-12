/*
	Get all the order information for any order where Chai was sold.
*/

USE Northwind;
GO

Select *
FROM Products
	INNER JOIN [Order Details] ON
		[Order Details].ProductID = Products.ProductID
	INNER JOIN Orders ON
		Orders.OrderID = [Order Details].OrderID
	WHERE ProductName = 'Chai';
