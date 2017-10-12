/*
	Find a list of all the Employees who have never found a Grant
*/

USE SWCCorp;
GO

Select e.FirstName, e.LastName
From Employee e
	LEFT JOIN [Grant] ON
		e.EmpID = [Grant].EmpID
	WHERE [Grant].EmpID is Null
