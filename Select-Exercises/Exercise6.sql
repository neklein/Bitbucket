/*
   Select the orders shipping to the USA whose freight is 
   between $10 and $20
*/

USE Northwind;
GO

SELECT *
FROM ORDERS
WHERE ShipCountry = 'usa'
AND FREIGHT > 10.00
AND FREIGHT < 20;