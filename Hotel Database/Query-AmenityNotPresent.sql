SELECT r.roomID FROM 
Room r WHERE r.roomID NOT IN
(SELECT r.roomID
FROM Room r
	LEFT JOIN RoomAmenity ra on r.roomID = ra.roomID
	LEFT JOIN Amenity a on ra.amenityID = a.amenityID
WHERE a.amenityType = 'Jacuzzi')
