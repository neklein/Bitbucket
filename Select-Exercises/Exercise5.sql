/*
   Select the orders whose freight is more than $100.00
*/

USE Northwind;
GO

SELECT *
FROM ORDERS
WHERE FREIGHT > '100'