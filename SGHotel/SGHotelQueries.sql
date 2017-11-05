USE SGHotel;
GO

-- returns all rooms for a customer

SELECT h.RoomNumber, c.FirstName, c.LastName, rt.FromDate, rt.ToDate
FROM HotelRoom h
	INNER JOIN HotelRoomPrice hrp ON h.RoomID = hrp.RoomID
	INNER JOIN ReservationTable rt ON rt.HotelRoomPriceID = hrp.HotelRoomPriceID
	INNER JOIN CustomerBill cb ON cb.CustomerBillID = rt.CustomerBillID
	INNER JOIN Customer c ON c.CustomerID = cb.CustomerID
WHERE c.FirstName = 'Charles'

-- return 3 most expensive bills for August

SELECT cb.TotalCharge
FROM CustomerBill cb
	INNER JOIN Customer c ON c.CustomerID = cb.CustomerID
	INNER JOIN ReservationTable rt ON rt.CustomerBillID = cb.CustomerBillID
WHERE rt.ToDate BETWEEN '08/01/2017' AND '08/31/2017'
GROUP BY cb.CustomerID, cb.TotalCharge
ORDER BY cb.TotalCharge DESC
	OFFSET 0 ROWS
	FETCH NEXT 3 ROWS ONLY
 

--return room withOUT specific amenity -> below returns room wtih spec amenity INCOMPLETE

SELECT h.RoomNumber
FROM HotelRoom h
WHERE h.RoomID NOT IN
(SELECT h.RoomID
FROM HotelRoom h
	INNER JOIN RoomAmenitiesHotelRoom rahr ON rahr.RoomID = h.RoomID
WHERE rahr.AmenityID = 1)

