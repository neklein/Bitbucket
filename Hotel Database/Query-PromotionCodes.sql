SELECT p.promoType, COUNT(rr.promotionID) AS [Times Used]
FROM RoomReservation rr
	RIGHT JOIN Promotion p ON rr.promotionID = p.promotionID
GROUP BY p.promoType  