/*
	Write a query to show every combination of employee and location.
*/

USE SWCCorp;
GO

Select e.FirstName, e.LastName, l.City
FROM Employee e
	Cross JOIN [Location] l
