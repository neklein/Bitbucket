/*
   Write a single query to display only the name and number of 
   units in stock for the products Laughing Lumberjack Lager, 
   Outback Lager, and Ravioli Angelo
*/

USE Northwind;
GO

SELECT PRODUCTNAME, UNITSINSTOCK
FROM PRODUCTS
WHERE PRODUCTNAME = 'LAUGHING LUMBERJACK LAGER' 
OR PRODUCTNAME = 'OUTBACK LAGER'
OR PRODUCTNAME = 'RAVIOLI ANGELO';
