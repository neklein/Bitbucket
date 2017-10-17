SELECT c.FirstName, c.LastName, r.number
FROM Customer c
	INNER JOIN GuestRoom gr ON c.customerID = gr.customerID
	INNER JOIN Room r ON gr.roomID = r.roomID
WHERE c.FirstName = 'Jim' AND c.LastName = 'Bob'
  